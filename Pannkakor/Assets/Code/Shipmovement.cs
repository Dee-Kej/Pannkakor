using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shipmovement : MonoBehaviour
{
    public int life = 3;
    public static Shipmovement Instance;
    float accelerationForce = 20f;
    float rotationForce = 100f;
    public GameObject bullet;
    public GameObject projectileSpawn;
    public Rigidbody2D rb;
    public ParticleSystem exhaust;
    public ParticleSystem exhaust2;
    public ParticleSystem leftThruster;
    public ParticleSystem rightThruster;
    public ParticleSystem Death;
    
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
    Collider2D col;
    public GameObject Spawn;
    
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Spawn = GameObject.Find("Spawner");
        col = GetComponent<Collider2D>();
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
        print(life);

        if (life <= 0)
        {
            Destroy(gameObject);
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
        else if (Input.GetAxis(axisNameH) == 0 && Input.GetAxis(axisNameV) >= 0)
        {
            leftThruster.gameObject.SetActive(false);
            rightThruster.gameObject.SetActive(false);
        }

        if (Input.GetAxis(axisNameV) == 0 && rb.angularVelocity != 0)
        {
            StabilizeShip();
        }

        if (Input.GetButtonDown(fireButton))
            ShootBullet();
        if (Tookdmg)
        {
            
            Rend.enabled = false;
            col.enabled = false;
            if (!Death.isPlaying)
            {
                switch (gameObject.tag)
                {
                    case "Player1":
                        transform.position = Spawn.GetComponent<SpawnPlayers>().spawnpoints[0].transform.position;
                        Spawn.GetComponent<SpawnPlayers>().player1.GetComponent<Shipmovement>().rb.Sleep();
                        break;
                    case "Player2":
                        transform.position = Spawn.GetComponent<SpawnPlayers>().spawnpoints[1].transform.position;
                        Spawn.GetComponent<SpawnPlayers>().player2.GetComponent<Shipmovement>().rb.Sleep();
                        break;
                    case "Player3":
                        transform.position = Spawn.GetComponent<SpawnPlayers>().spawnpoints[2].transform.position;
                        Spawn.GetComponent<SpawnPlayers>().player3.GetComponent<Shipmovement>().rb.Sleep();
                        break;
                    case "Player4":
                        transform.position = Spawn.GetComponent<SpawnPlayers>().spawnpoints[3].transform.position;
                        Spawn.GetComponent<SpawnPlayers>().player4.GetComponent<Shipmovement>().rb.Sleep();
                        break;
                    default:
                        Debug.Log("Is borken");
                        break;
                }
               
                Rend.enabled = true;
                col.enabled = true;
                Tookdmg = false;
            }
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
                if (GrabControllerBool)
                {
                    print(GrabControllerBool);
                    Temp[i].transform.gameObject.GetComponent<AstroidScript>()._Connected = false;
                    
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
