using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shipmovement : MonoBehaviour {

    float accelerationForce = 10f;
    float rotationForce = 100f;
    public GameObject bullet;

    // Use this for initialization
    void Start () {



    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationForce * Time.deltaTime);

        GetComponent<Rigidbody2D>()
            .AddForce(transform.up * accelerationForce * Input.GetAxis("Vertical"));

        if (Input.GetMouseButtonDown(0))
            ShootBullet();
    }

    void ShootBullet()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0),
            transform.rotation);
    }
}
