using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shipmovement : MonoBehaviour
{
    public int life = 3;
    public int stage = 3;
    public Sprite[] dmgship1, dmgship2, brokenship;

    public static Shipmovement Instance;
    float accelerationForce = 5f;
    float rotationForce = 100f;
    public GameObject bullet;
    public GameObject projectileSpawn;
    public Rigidbody2D rb;
    public ParticleSystem exhaust;
    public ParticleSystem exhaust2;
    public ParticleSystem leftThruster;
    public ParticleSystem rightThruster;
    public ParticleSystem Death;

    private bool slowdown = false;
    
    [Space]
    public Vector2 BoxSize,_ParticlePos;
    public float angle,_particleStep,RayRange, Distance,DotValue;
    string axisNameH;
    string axisNameV;
    string fireButton;
    string grabButton;
    public bool GrabControllerBool;
    public bool Tookdmg;
    Renderer Rend;
    PolygonCollider2D col;
    public GameObject Spawn;
    SpriteRenderer spriterend;
    bool dead = false;

    float startTime = 0, elapsedTime = 0, okToShootAgainTime = 0.25f;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        spriterend = GetComponent<SpriteRenderer>();
        Spawn = GameObject.Find("Spawner");
        col = GetComponent<PolygonCollider2D>();
        Rend = GetComponent<Renderer>();
        Death.Stop();
        GrabControllerBool = false;
        switch (gameObject.tag)
        {
            
            case "Player1":
                axisNameH = "Horizontal";
                axisNameV = "Vertical";
                fireButton = "Fire1";
                grabButton = "Grab1";
                break;
            case "Player2":
                axisNameH = "Horizontal2";
                axisNameV = "Vertical2";
                fireButton = "Fire2";
                grabButton = "Grab2";
                break;
            case "Player3":
                axisNameH = "Horizontal3";
                axisNameV = "Vertical3";
                fireButton = "Fire3";
                grabButton = "Grab3";
                break;
            case "Player4":
                axisNameH = "Horizontal4";
                axisNameV = "Vertical4";
                fireButton = "Fire4";
                grabButton = "Grab4";
                break;
            default:
                break;
        }
        
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        


        elapsedTime = Time.time - startTime;


        switch (stage)
        {
            case 2:
                if(gameObject.tag == "Player1")
                {
                    spriterend.sprite = dmgship1[0];
                }
                else if (gameObject.tag == "Player2")
                {
                    spriterend.sprite = dmgship1[1];
                }
                else if (gameObject.tag == "Player3")
                {
                    spriterend.sprite = dmgship1[2];
                }
                else if (gameObject.tag == "Player4")
                {
                    spriterend.sprite = dmgship1[3];
                }

                break;

            case 1:
                if (gameObject.tag == "Player1")
                {
                    spriterend.sprite = dmgship2[0];
                }
                else if (gameObject.tag == "Player2")
                {
                    spriterend.sprite = dmgship2[1];
                }
                else if (gameObject.tag == "Player3")
                {
                    spriterend.sprite = dmgship2[2];
                }
                else if (gameObject.tag == "Player4")
                {
                    spriterend.sprite = dmgship2[3];
                }
                break;


            case 0:
                if (gameObject.tag == "Player1")
                {
                    spriterend.sprite = brokenship[0];
                }
                else if (gameObject.tag == "Player2")
                {
                    spriterend.sprite = brokenship[1];
                }
                else if (gameObject.tag == "Player3")
                {
                    spriterend.sprite = brokenship[2];
                }
                else if (gameObject.tag == "Player4")
                {
                    spriterend.sprite = brokenship[3];
                }
                break;
        }


        transform.Rotate(0, 0, -Input.GetAxis(axisNameH) * rotationForce * Time.deltaTime);

        rb.AddForce(transform.up * accelerationForce * Input.GetAxis(axisNameV));

        if (Input.GetAxis(axisNameV) == 0)
        {
            GetComponent<AudioSource>().Stop();
            exhaust.gameObject.SetActive(false);
            exhaust2.gameObject.SetActive(false);
        }
        else if (Input.GetAxis(axisNameV) > 0)
        {
            exhaust.gameObject.SetActive(true);
            exhaust2.gameObject.SetActive(true);
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
        else if (Input.GetAxis(axisNameH) < 0)
        {
            rightThruster.gameObject.SetActive(true);
        }
        else if (Input.GetAxis(axisNameH) == 0 && Input.GetAxis(axisNameV) == 0)
        {
            leftThruster.gameObject.SetActive(false);
            rightThruster.gameObject.SetActive(false);
        }

        if (Input.GetAxis(axisNameV) < 0.1 && Input.GetAxis(axisNameV) > -0.1)
        {
            StabilizeShip();
        }

        if (Input.GetButtonDown(fireButton) && elapsedTime > okToShootAgainTime)
        {
            Debug.Log("lol");
            startTime = Time.time;
            //shoot
            ShootBullet();
        }

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, 0, 100), Mathf.Clamp(rb.velocity.y, 0, 100));

        if (Tookdmg)
        {
            print(life + " Life");
            print(stage + " Stage");
            stage--;
            Tookdmg = false;
            if (stage <= 0)
            {
                life--;
                stage = 3;
                // Rend.enabled = false;
                col.enabled = false;
                /*Spawn.GetComponent<SpawnPlayers>().player1.GetComponent<Shipmovement>().*/
                Death.Play();
                dead = true;
                GetComponent<SpriteRenderer>().enabled = false;

                //switch (gameObject.tag)
                //{
                //    case "Player1":

                //        break;
                //    case "Player2":
                //        Spawn.GetComponent<SpawnPlayers>().player2.GetComponent<Shipmovement>().Death.Play();
                //        break;
                //    case "Player3":
                //        Spawn.GetComponent<SpawnPlayers>().player3.GetComponent<Shipmovement>().Death.Play();
                //        break;
                //    case "Player4":
                //        Spawn.GetComponent<SpawnPlayers>().player4.GetComponent<Shipmovement>().Death.Play();
                //        break;
                //    default:
                //        Debug.Log("Is borken");
                //        break;
                //}



                //switch (gameObject.tag)
                //{
                //    case "Player1":
                //        transform.position = Spawn.GetComponent<SpawnPlayers>().spawnpoints[0].transform.position;
                //        Spawn.GetComponent<SpawnPlayers>().player1.GetComponent<Shipmovement>().rb.Sleep();
                //        col.enabled = true;
                //        break;
                //    case "Player2":
                //        transform.position = Spawn.GetComponent<SpawnPlayers>().spawnpoints[1].transform.position;
                //        Spawn.GetComponent<SpawnPlayers>().player2.GetComponent<Shipmovement>().rb.Sleep();
                //        col.enabled = true;
                //        break;
                //    case "Player3":
                //        transform.position = Spawn.GetComponent<SpawnPlayers>().spawnpoints[2].transform.position;
                //        Spawn.GetComponent<SpawnPlayers>().player3.GetComponent<Shipmovement>().rb.Sleep();
                //        col.enabled = true;
                //        break;
                //    case "Player4":
                //        transform.position = Spawn.GetComponent<SpawnPlayers>().spawnpoints[3].transform.position;
                //        Spawn.GetComponent<SpawnPlayers>().player4.GetComponent<Shipmovement>().rb.Sleep();
                //        col.enabled = true;
                //        break;
                //    default:
                //        Debug.Log("Is borken");
                //        break;

                //}


                // Rend.enabled = true;

                StartCoroutine(StopDeath());


            }
        }
        print(life);
        print(stage);
        Tookdmg = false;
        if (life <= 0)
        {
            Destroy(gameObject);
        }

        if (slowdown)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 5 * Time.deltaTime);
            rb.angularVelocity = Mathf.Lerp(rb.angularVelocity, 0, 5 * Time.deltaTime);
        }
              
        RaycastHit2D[] Temp = Physics2D.BoxCastAll(transform.position, BoxSize, angle, Quaternion.identity.eulerAngles, Distance);


        if (Input.GetButtonDown(grabButton))
        {
            for (int i = 0; i < Temp.Length; i++)
            {
                float dot = Vector2.Dot(transform.up, (Temp[i].transform.position - transform.position).normalized);

               
                if (Temp[i].transform.CompareTag("Astroid") && dot > DotValue && !GrabControllerBool)
                {
                    
                    Temp[i].transform.gameObject.GetComponent<AstroidScript>()._Connected = true;
                    Temp[i].transform.GetComponent<SpringJoint2D>().connectedBody = rb;
                    GrabControllerBool = true;
                }
               else if (GrabControllerBool)
                {
                    print(GrabControllerBool);
                    Temp[i].transform.gameObject.GetComponent<AstroidScript>()._Connected = false;
                    GrabControllerBool = false;
                    
                }
              

                Debug.Log("u hit the astroid");

                if (Temp[i] && dot > DotValue)
                {

                    Debug.DrawLine(transform.position, Temp[i].transform.position, Color.green);
                }
            }
        }
    }

    void ShootBullet()
    {
        Debug.Log("lol nje");
        Instantiate(bullet, projectileSpawn.transform.position, transform.rotation);//new Vector3(transform.position.x, transform.position.y),transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        rb.velocity = new Vector3(0, 0, 0);

    }

    void StabilizeShip()
    {
        StartCoroutine(WaitStablelize());
    }

    IEnumerator WaitStablelize()
    {
        yield return new WaitForSeconds(1.5f);

        if (Input.GetAxis(axisNameV) < 0.1 && Input.GetAxis(axisNameV) > -0.1)
        {
            slowdown = true;
        }
        else
        {
            slowdown = false;
        }

    }

    IEnumerator StopDeath()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("not dead");
        if (gameObject.CompareTag("Player1"))
        {
            transform.position = Spawn.GetComponent<SpawnPlayers>().spawnpoints[0].transform.position;
        }
        else if (gameObject.CompareTag("Player2"))
        {
            transform.position = Spawn.GetComponent<SpawnPlayers>().spawnpoints[1].transform.position;
        }
        else if (gameObject.CompareTag("Player3"))
        {
            transform.position = Spawn.GetComponent<SpawnPlayers>().spawnpoints[2].transform.position;
        }
        else if (gameObject.CompareTag("Player4"))
        {
            transform.position = Spawn.GetComponent<SpawnPlayers>().spawnpoints[3].transform.position;
        }

        rb.Sleep();
        col.enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
