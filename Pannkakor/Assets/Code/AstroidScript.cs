using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidScript : MonoBehaviour
{

    SpringJoint2D _Joint;
    [Space]
    Rigidbody2D rb;

    float Rotationvalue;

   public static bool _Connected;
	
	void Start ()
    {
        Rotationvalue = Random.Range(-5f, 5f);
       
        _Connected = false;
        _Joint = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
        _Joint.enabled = false;
    }
	
	
	void Update ()
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
            transform.Rotate(0, 0,Rotationvalue);
            if (Rotationvalue == 0)
            {
                Rotationvalue = Random.Range(-5f, 5f);
            }
        }
        
    }
}
