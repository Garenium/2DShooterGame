using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform TargetSprite;
    public Transform spawnPoint;
    private Score scoreScript;
    public GameObject enemy;
    //private Enemy enemyScript;
    private float randomX = 0.0f;
    private float randomY = 0.0f;

    void Start()
    {
        TargetSprite = GameObject.Find("Main Character").transform;
        //scoreScript = GameObject.Find("Text").ScoreScript;

        int i = 0;
        int max = (int)(10 * PlayerPrefs.GetFloat("DIFF"));
        while (i < max)
        {
            Debug.Log("Spawn!");
            spawnPoint = setSpawn();
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);

            ++i;
            //Debug.Log(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionToPlayer = TargetSprite.position - transform.position;
        transform.up = directionToPlayer;
        transform.Translate(Vector2.up * 5.0f * Time.deltaTime);
    }

    public Transform setSpawn()
    {
        int randomSide = Random.Range(0, 4);   //Where 4 is exclusive

        if (randomSide == 0)
        {
            randomX = Random.Range(-13.0f, 13.0f);
            randomY = Random.Range(5.0f, 8.0f);
        }
        else if (randomSide == 1)
        {
            randomX = Random.Range(10.0f, 13.0f);
            randomY = Random.Range(-13.0f, 13.0f);
        }
        else if (randomSide == 2)
        {
            randomX = Random.Range(-13.0f, 13.0f);
            randomY = Random.Range(-5.0f, -8.0f);
        }
        else if (randomSide == 3)
        {
            randomX = Random.Range(-13.0f, -10.0f);
            randomY = Random.Range(-13.0f, 13.0f);
        }
        Vector2 AdjustCoordinate;
        AdjustCoordinate.x = randomX;
        AdjustCoordinate.y = randomY;
        spawnPoint.position = AdjustCoordinate;
        return spawnPoint;
    }

    public void OnCollisionEnter2D(Collision2D bullet)
    {
        if (bullet.gameObject.CompareTag("Bullets"))
        {
            Destroy(bullet.gameObject); //This destroys the bullet
            scoreScript.increaseScore();

            //Transform spawnPoint = enemyScript.setSpawn();
            Transform spawnPoint = setSpawn();

            this.transform.position = spawnPoint.position;
            this.transform.rotation = spawnPoint.rotation;

            //isDestroyed = true;
            //reSpawn();
        }
    }
}
