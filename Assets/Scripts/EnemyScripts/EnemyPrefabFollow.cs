using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabFollow : MonoBehaviour
{
    //Only follows 

    private Transform TargetSprite;
    public Transform spawnPoint;
    private GameObject scoreObj;
    private Enemy enemyScript;
    private Score scoreScript;
    private Canvas canvas;
    float randomX = 0.0f;
    float randomY = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        TargetSprite = GameObject.Find("Main Character").transform;
        //canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
         scoreScript = GameObject.Find("Text").GetComponent<Score>();
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

            Destroy(bullet.gameObject);

            spawnPoint = setSpawn();

            this.transform.position = spawnPoint.position;
            this.transform.rotation = spawnPoint.rotation;

            scoreScript.increaseScore();
            //scoreObj.GetComponent<Score>().increaseScore();

            //enemyScript.respawnPosition();

            //isDestroyed = true;
            //reSpawn();
        }
    }
}
