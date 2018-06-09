using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shipmovement : MonoBehaviour
{

    float accelerationForce = 20f;
    float rotationForce = 100f;
    public GameObject bullet;
    public GameObject projectileSpawn;
    public Rigidbody2D rb;
    public ParticleSystem exhaust;
    public ParticleSystem leftThruster;
    public ParticleSystem rightThruster;
    [Space]
    public Vector2 BoxSize;
    public float angle,Distance;
    string axisNameH;
    string axisNameV;
    
    void Start()
    {
        switch (gameObject.tag)
        {
            case "Player1":
                axisNameH = "Horizontal";
                axisNameV = "Vertical";
                break;
            case "Player2":
                axisNameH = "Horizontal2";
                axisNameV = "Vertical2";
                break;
            case "Player3":
                axisNameH = "Horizontal3";
                axisNameV = "Vertical3";
                break;
            case "Player4":
                axisNameH = "Horizontal4";
                axisNameV = "Vertical4";
                break;
            default:
                break;
        }
        
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {


        transform.Rotate(0, 0, -Input.GetAxis(axisNameH) * rotationForce * Time.deltaTime);


        rb.AddForce(transform.up * accelerationForce * Input.GetAxis(axisNameV));

        if (Input.GetAxis(axisNameV) == 0)
        {
            GetComponent<AudioSource>().Stop();
            exhaust.gameObject.SetActive(false);
        }
        else if (Input.GetAxis(axisNameV) > 0)
        {
            exhaust.gameObject.SetActive(true);
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
        }

        if (Input.GetAxis(axisNameV) < 0)
        {
            leftThruster.gameObject.SetActive(true);
            rightThruster.gameObject.SetActive(true);

        }
       
        if (Input.GetAxis(axisNameH) > 0)
        {
            leftThruster.gameObject.SetActive(true);
        }
        else if(Input.GetAxis(axisNameH) < 0)
        {
            rightThruster.gameObject.SetActive(true);
        }
       else if (Input.GetAxis(axisNameH) == 0 && Input.GetAxis(axisNameV) >= 0)
        {
            leftThruster.gameObject.SetActive(false);
            rightThruster.gameObject.SetActive(false);
        }

        if (Input.GetAxis(axisNameV) == 0 && rb.angularVelocity != 0)
        {
            StabilizeShip();
        }

        if (Input.GetMouseButtonDown(0))
            ShootBullet();

        RaycastHit2D[] Temp = Physics2D.BoxCastAll(transform.position, BoxSize, angle, Quaternion.identity.eulerAngles,Distance);

        for (int i = 0; i < Temp.Length; i++)
        {
            if (Temp[i].transform.CompareTag("Astroid") && Input.GetKeyDown(KeyCode.X))
                {

                Temp[i].transform.gameObject.GetComponent<AstroidScript>()._Connected = true;
                Temp[i].transform.GetComponent<SpringJoint2D>().connectedBody = rb;
                Debug.Log("u hit the astjrnieno)");
            }
        } 

    }

    void ShootBullet()
    {
        Instantiate(bullet, projectileSpawn.transform.position, transform.rotation);//new Vector3(transform.position.x, transform.position.y),transform.rotation);
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
