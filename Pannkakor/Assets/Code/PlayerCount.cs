using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCount : MonoBehaviour {

    public bool player1, player2, player3, player4;
    public GameObject pressS, pressK;


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        player1 = player2 = player3 = player4 = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.S) && !player1)
        {
            player1 = true;
            Debug.Log("player 1 ready");
            pressS.SetActive(false);
        }

        else if (Input.GetKeyDown(KeyCode.K) && !player2)
        {
            player2 = true;
            Debug.Log("player 2 ready");
            pressK.SetActive(false);
        }
	}
}
