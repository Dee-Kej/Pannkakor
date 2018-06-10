using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    public AudioClip[] audioclips;
    public Sprite[] bulletSprites;
    GameObject Spawn;
	void Start () {
        Spawn = GameObject.Find("Spawner");
        GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);
        //Debug.Log("Waking up");
        GetComponent<AudioSource>().clip = audioclips[Random.Range(0, audioclips.Length-1)];
        GetComponent<AudioSource>().Play();

        StartCoroutine(KillBullet());
	}

    void FixedUpdate()
    {
        GetComponent<SpriteRenderer>().sprite = bulletSprites[Random.Range(0, bulletSprites.Length - 1)];
    }
	
    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Player1":
                //Debug.Log("I'm hitting a Player!!");
              
                Spawn.GetComponent<SpawnPlayers>().player1.GetComponent<Shipmovement>().Tookdmg = true;
                

                break;
            case "Player2":
                //Debug.Log("I'm hitting a Player!!");
                
                Spawn.GetComponent<SpawnPlayers>().player2.GetComponent<Shipmovement>().Tookdmg = true;
               

                break;
            case "Player3":
                //Debug.Log("I'm hitting a Player!!");
              
                Spawn.GetComponent<SpawnPlayers>().player3.GetComponent<Shipmovement>().Tookdmg = true;
               
                break;
            case "Player4":
                //Debug.Log("I'm hitting a Player!!");
       
                Spawn.GetComponent<SpawnPlayers>().player4.GetComponent<Shipmovement>().Tookdmg = true;
              

                break;
            case "Astroid":
                //Debug.Log("I'm hitting an Asteroid!!");
                Destroy(this.gameObject);
                break;
            case "Border":
                //Debug.Log("I'm hitting the border!!");
                Destroy(this.gameObject);
                break;
            default:
                //Debug.Log("Not a name I'm recognizing!");
                break;
        }

    }
    IEnumerator KillBullet()
    {
        yield return new WaitForSeconds(3f);
        if (this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
    }

}
