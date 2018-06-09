using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public GameObject bulletObject;

	void Update () {

        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(bulletObject, this.transform);
        }
	}
}
