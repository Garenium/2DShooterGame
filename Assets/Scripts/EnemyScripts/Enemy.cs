using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    //Only instantiate

    //public Transform TargetSprite;
    public Transform spawnPoint;
    public GameObject enemy;
    //public GameObject sliderPrefab;
    //public GameObject bulletPrefab;
    float randomX = 0.0f;
    float randomY = 0.0f;
    //private bool addedPoint = false;
    public Score scoreScript;
    //private MenuScript menuScript;
    //private Transform playerTransform;
    //public Slider sliderDifficulty;

    //bool isDestroyed = false;

    void Start()
    {
        //Slider sliderValue = sliderPrefab.GetComponent.;
        Debug.Log(PlayerPrefs.GetFloat("DIFF"));
        int max = (int)(10*PlayerPrefs.GetFloat("DIFF"));
        int i = 0;
        while(i < max)
        {
            spawnPoint = setSpawn();
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            
            ++i;
            //Debug.Log(i);
        }
    }
    //// Update is called once per frame
    //void Update()
    //{
    //    Vector2 directionToPlayer = TargetSprite.position - transform.position;
    //    transform.up = directionToPlayer;
    //    transform.Translate(Vector2.up * 5.0f * Time.deltaTime);

    //    if(Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        //Debug.Log("Escape Key");
    //        SceneManager.LoadScene("Menu");
    //    }
    //}


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


    //public void OnCollisionEnter2D(Collision2D bullet)
    //{
    //    if (bullet.gameObject.CompareTag("Bullets"))
    //    {

    //        Destroy(bullet.gameObject);
    //        scoreScript.increaseScore();

    //        spawnPoint = setSpawn();

    //        enemy.transform.position = spawnPoint.position;
    //        enemy.transform.rotation = spawnPoint.rotation;
    //        //enemyScript.respawnPosition();

    //        //isDestroyed = true;
    //        //reSpawn();
    //    }
    //}
    //public void OnCollisionEnter2D(Collision2D bullet)
    //{
    //    if (bullet.gameObject.CompareTag("Bullets"))
    //    {
    //        //Destroy(bullet.gameObject); //This destroys the bullet
    //        //scoreScript.increaseScore();

    //        //spawnPoint = setSpawn();

    //        //this.transform.position = spawnPoint.position;
    //        //this.transform.rotation = spawnPoint.rotation;

    //        Destroy(bullet.gameObject); //This destroys the bullet
    //                                    //respawnPosition();
    //        scoreScript.increaseScore();

    //        spawnPoint = setSpawn();

    //        this.transform.position = spawnPoint.position;
    //        this.transform.rotation = spawnPoint.rotation;
    //        //isDestroyed = true;
    //        //reSpawn();
    //    }

    //}

    //public void respawnPosition()
    //{      
    //    scoreScript.increaseScore();

    //    spawnPoint = setSpawn();

    //    this.transform.position = spawnPoint.position;
    //    this.transform.rotation = spawnPoint.rotation;
    //}


    //void reSpawn()
    //{
    //    spawnPoint = setSpawn();
    //    transform.position = spawnPoint.position;
    //    transform.rotation = spawnPoint.rotation;
    //    Instantiate(enemy, transform.position, transform.rotation);
    //}
}