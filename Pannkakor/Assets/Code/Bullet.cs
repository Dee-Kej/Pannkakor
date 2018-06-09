using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour {

    public AudioClip[] audioclips;


    
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);
        Debug.Log("Waking up");
        GetComponent<AudioSource>().clip = audioclips[Random.Range(0, audioclips.Length-1)];
        GetComponent<AudioSource>().Play();
	}
	
    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.name)
        {
            case "Player":
                Debug.Log("I'm hitting a Player!!");
                break;
            case "Asteroid":
                Debug.Log("I'm hitting an Asteroid!!");
                break;
            case "Border":
                Debug.Log("I'm hitting the border!!");
                Destroy(this.gameObject);
                break;
            default:
                Debug.Log("Not a name I'm recognizing!");
                break;
        }
    }

}
