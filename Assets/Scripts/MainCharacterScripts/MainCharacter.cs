using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacter : MonoBehaviour
{
   public float speed;
   private Vector2 screenBounds;
   public Animator animator;
   //public Collider2D collision;
   public AudioSource audioPlay;
   bool isCollided = false;
   private float timeLeft = 1;
   public Rigidbody2D rb;
   private Vector2 movement;
   //public GameObject prefab;
   //private GameObject prefabClone;

    // Update is called once per frame
    void Update()
    {

        if (isCollided == true)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
                SceneManager.LoadScene("Main");
        }

        //Don't let the character go anywhere out of the camera's point of view
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9f, 9f),
            Mathf.Clamp(transform.position.y, -5f, 5f), transform.position.z);


        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("Escape Key");
            SceneManager.LoadScene("Menu");
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            audioPlay.Play();
            isCollided = true;
            
            
        }
    }

}

//OnCollisionEnter2D(collision);
//GameObject.Find("Bullets").GetComponent<Collider>().isTrigger = true;

//animator.SetBool("Moving", false);


//prefab.GetComponent<Collider>().isTrigger = true;


////WASD movement configuration
//if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
//{
//    //animator.SetBool("Moving", true);
//    transform.Translate(Vector3.up * speed * Time.deltaTime);

//}

//if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
//{
//    //animator.SetBool("Moving", true);
//    transform.Translate(Vector3.down * speed * Time.deltaTime);

//}

//if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
//{
//    //animator.SetBool("Moving", true);
//    transform.Translate(Vector3.left * speed * Time.deltaTime);

//}

//if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
//{
//    //animator.SetBool("Moving", true);
//    transform.Translate(Vector3.right * speed * Time.deltaTime);
//}