using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCGun : MonoBehaviour
{
    private Transform aimTransform;
    private GameObject gun;
    public GameObject bulletPrefab;

    //float fireTime = 1.0f;
    //public AudioSource audioSound;
    //ObjectPooler objectPooler;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -10.0f;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = mousePosition - transform.position;
        float angle = 90.0f - (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        Quaternion rotation = transform.rotation;

    }

    //void Shoot(Vector3 direction)
    //{
    //    audioSound.Play();///play the sound
    //    float angle = 90 - (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg); //adjust the angle
    //    transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
    //    //Initialize the bullet
    //    GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
    //}
}
