using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    //public GameObject enemy;
    public AudioSource audioSound;
    public Transform gunTransform;
    public MCGun gunScript;

    float angle;
    float fireRate = 0.2f;
    float nextFire = 0.0f;

    public float bulletForce = 3;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            audioSound.Play();
            Shoot();
        }

        if (Input.GetMouseButton(1) && Time.time > nextFire)
        {
            audioSound.Play();
            nextFire = Time.time + fireRate;
            Shoot();
        }


        //if (bulletPrefab.transform.position.x > 10 || bulletPrefab.transform.position.x < -10)
        //{
        //    Destroy(bulletPrefab);
        //}

        //if (bulletPrefab.transform.position.y > 6 || bulletPrefab.transform.position.y < -6)
        //{
        //    Destroy(bulletPrefab);
        //}
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(gunTransform.up * bulletForce, ForceMode2D.Impulse);
    }

}
