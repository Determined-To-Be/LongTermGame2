﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherHPLayerController : MonoBehaviour
{
    Vector2 mouse;
    public float shootForce;
    Rigidbody2D rb;
    Vector2 faceDirection;
    public GameObject bullet;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mouse = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        faceDirection =(mouse - rb.position).normalized;
        float faceAngle = (Mathf.Atan2(faceDirection.y,faceDirection.x) * Mathf.Rad2Deg)-90;
        rb.SetRotation(faceAngle);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }
    void Shoot()
    {
        rb.velocity = (rb.velocity + (faceDirection * shootForce));
        GameObject newBullet = Instantiate(bullet, this.gameObject.transform.GetChild(0).transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = -1 *faceDirection * bulletSpeed;

    }
}
