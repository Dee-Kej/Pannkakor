using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawnerScript : MonoBehaviour
{

    
   public GameObject Astroid;
    List<GameObject> Astroids;
    Vector2[] AstroidDefaultPos;
    Vector3 Camvalue;

	void Start ()
    {
        // Astroid = Resources.Load<GameObject>("Prefabs/Astroids");
        Camvalue = Camera.main.ViewportToWorldPoint(transform.position);

        for (float i = Camvalue.x + 1; i < (Camvalue.x * -1); i += 2f)
        {
            Instantiate(Astroid, new Vector3(i, Camvalue.y, 0), Quaternion.identity);
            Instantiate(Astroid, new Vector3(i, -Camvalue.y + 2, 0), Quaternion.identity);
        }
        for (float i = -Camvalue.y + 3.5f; i < Camvalue.y; i += 2f)
        {
            Instantiate(Astroid, new Vector3(Camvalue.x, i, 0), Quaternion.identity);
            Instantiate(Astroid, new Vector3(-Camvalue.x, i, 0), Quaternion.identity);

        }

        print(Camvalue);
       

    }


    void Update ()
    {
		
	}
}
