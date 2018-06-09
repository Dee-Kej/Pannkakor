using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddForce(transform.up * 1000);
        Debug.Log("Waking up");
	}
	
    void OnTriggerEnter(Collider collider)
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
