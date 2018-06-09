using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidScript : MonoBehaviour
{

    SpringJoint2D _Joint;
    [Space]
    Rigidbody2D rb;

    

   public static bool _Connected;
	
	void Start ()
    {
        _Connected = true;
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
        }
        print("Joint is " + _Joint.isActiveAndEnabled + " And Connected is " + _Connected);      
    }
}
