﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidScript : MonoBehaviour
{
    public static AstroidScript instance;
    SpringJoint2D _Joint;
    [Space]
    Rigidbody2D rb;

    float Rotationvalue;

    public static bool _Connected;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Rotationvalue = Random.Range(-5f, 5f);

        _Connected = false;
        _Joint = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
        _Joint.enabled = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _Connected = false;
        }
        if (_Connected)
        {
            _Joint.enabled = true;
        }
        else if (!_Connected)
        {
            _Joint.enabled = false;
            rb.drag = 0;
            transform.Rotate(0, 0, Rotationvalue);
            if (Rotationvalue == 0)
            {
                Rotationvalue = Random.Range(-5f, 5f);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "Bullet":
                transform.localScale *= 1.15f;
                GetComponent<AudioSource>().Play();
                break;
            case "Ship":
                Destroy(collision.gameObject);
                GetComponent<AudioSource>().Play();
                break;
            default:
                Debug.Log("Unknown Collision");
                break;
        }
    }
}
