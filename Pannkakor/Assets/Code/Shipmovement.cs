using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shipmovement : MonoBehaviour
{

    float accelerationForce = 10f;
    float rotationForce = 100f;
    public GameObject bullet;
    public Rigidbody2D rb;
    public ParticleSystem exhaust;
    [Space]
    public Vector2 BoxSize;
    public float angle,Distance;
    
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        exhaust = GetComponentInChildren<ParticleSystem>();
    }


    void FixedUpdate()
    {

        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationForce * Time.deltaTime);


        rb.AddForce(transform.up * accelerationForce * Input.GetAxis("Vertical"));

        if (Input.GetAxis("Vertical") == 0)
        {
            exhaust.gameObject.SetActive(false);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            exhaust.gameObject.SetActive(true);
            GetComponent<AudioSource>().Play();
        }

        if (Input.GetAxis("Vertical") == 0 && rb.angularVelocity != 0)
        {
            StabilizeShip();
        }

        if (Input.GetMouseButtonDown(0))
            ShootBullet();

        RaycastHit2D[] Temp = Physics2D.BoxCastAll(transform.position, BoxSize, angle, Quaternion.identity.ToEulerAngles(),Distance);

        for (int i = 0; i < Temp.Length; i++)
        {
            if (Temp[i].transform.CompareTag("Astroid") && Input.GetKeyDown(KeyCode.X))
                {
                AstroidScript.instance._Connected = true;
                //AstroidScript.instance._Joint.connectedBody = rb;
                
                Temp[i].transform.GetComponent<SpringJoint2D>().connectedBody = rb;
                Debug.Log("u hit the astjrnieno)");
            }
        } 
       

       

    }

    void ShootBullet()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y),
            transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        rb.velocity = new Vector3(0, 0, 0);

    }

    void StabilizeShip()
    {
        StartCoroutine(WaitStablelize());
        rb.velocity = new Vector3(0, 0, 0);
        rb.angularVelocity = 0;

    }


    IEnumerator WaitStablelize()
    {
        yield return new WaitForSeconds(3);
    }
}
