using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueamount = 2f;
    [SerializeField] float boostspeed = 30f;
    [SerializeField] float basespeed = 20f;
    [SerializeField] float brakes = 10f;
    bool CanMove=true;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if(CanMove)
        {
            RotatePlayer();
            SpeedBoost();
        }
    }

    public void disableControls()
    {
        CanMove=false;
    }

    void SpeedBoost()
    {
        if(Input.GetKey(KeyCode.W))
        {
            surfaceEffector2D.speed = boostspeed;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            surfaceEffector2D.speed = brakes;
        }
        else
        {
            surfaceEffector2D.speed = basespeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqueamount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqueamount);
        }
    }
}
