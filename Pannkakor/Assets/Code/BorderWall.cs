using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderWall : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name);
        Destroy(collider.gameObject); 
    }
}
