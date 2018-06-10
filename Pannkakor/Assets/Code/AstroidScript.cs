using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidScript : MonoBehaviour
{
    public static AstroidScript instance;
   public SpringJoint2D _Joint;
    [Space]
    Rigidbody2D rb;
    Animator animator;
    float Rotationvalue;
    GameObject Spawn;
    

    public  bool _Connected;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Spawn = GameObject.Find("Spawner");
        Rotationvalue = Random.Range(-5f, 5f);
        animator = GetComponent<Animator>();
        _Connected = false;
        _Joint = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
        _Joint.enabled = false;
    }


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    _Connected = false;
        //}
        if (_Connected)
        {
            _Joint.enabled = true;
            rb.drag = 2.5f;
            
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
        switch (collision.gameObject.tag)
        {
            case "Bullet":
                transform.localScale *= 1.05f;
                animator.SetFloat("Scale", transform.localScale.x);
                GetComponent<AudioSource>().Play();
                break;
            case "Player1":

                Spawn.GetComponent<SpawnPlayers>().player1.GetComponent<Shipmovement>().Tookdmg = true;                         
                GetComponent<AudioSource>().Play();
                break;
            case "Player2":     
                Spawn.GetComponent<SpawnPlayers>().player2.GetComponent<Shipmovement>().Tookdmg = true;          
                GetComponent<AudioSource>().Play();
                break;
            case "Player3":
                
                Spawn.GetComponent<SpawnPlayers>().player3.GetComponent<Shipmovement>().Tookdmg = true;
                
          
                GetComponent<AudioSource>().Play();
                break;
            case "Player4":
              
                Spawn.GetComponent<SpawnPlayers>().player4.GetComponent<Shipmovement>().Tookdmg = true;
                
             
                GetComponent<AudioSource>().Play();

                break;
            case "Border":
                Debug.Log("hit border");
                break;
            default:
                Debug.Log("Unknown Collision");
                break;
        }
    }
}
