using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawnerScript : MonoBehaviour
{


    public GameObject Astroid;
    // List<GameObject> AstroidList;
    Vector2[] AstroidDefaultPos;
    Vector3 Camvalue;

   public List<GameObject> AstroidList = new List<GameObject>();

    void Start()
    {
       // Astroid = Resources.Load<GameObject>("Prefabs/Asteroid");
        Camvalue = Camera.main.ViewportToWorldPoint(transform.position);

        for (float i = Camvalue.x + 1; i < (Camvalue.x * -1); i += 2f)
        {        
            AstroidList.Add( Instantiate(Astroid, new Vector3(i, Camvalue.y, 0), Quaternion.identity));
            AstroidList.Add(Instantiate(Astroid, new Vector3(i, -Camvalue.y + 2, 0), Quaternion.identity));
        }
        for (float i = -Camvalue.y + 3.5f; i < Camvalue.y; i += 2f)
        {
            AstroidList.Add(Instantiate(Astroid, new Vector3(Camvalue.x, i, 0), Quaternion.identity));
            AstroidList.Add(Instantiate(Astroid, new Vector3(-Camvalue.x, i, 0), Quaternion.identity));
        }
       
    }


    void Update()
    {
        
    }
}
