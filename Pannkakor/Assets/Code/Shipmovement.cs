using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shipmovement : MonoBehaviour {

    float accelerationForce = 10f;
    float rotationForce = 100f;
    public GameObject bullet;
    public Rigidbody2D rb;
    void Start () {

       rb = GetComponent<Rigidbody2D>();

    }
	

	void FixedUpdate () {

        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationForce * Time.deltaTime);
            
        rb.AddForce(transform.up * accelerationForce * Input.GetAxis("Vertical"));

        if (Input.GetMouseButtonDown(0))
            ShootBullet();


    }

    void ShootBullet()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0),
            transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
           rb.velocity = new Vector3(0, 0, 0);
           
           


    }
}
