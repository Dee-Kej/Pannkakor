using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCount : MonoBehaviour {

    public bool player1, player2, player3, player4;
    public GameObject pressS, pressK, pressDown, press5;


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
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !player3)
        {
            player3 = true;
            Debug.Log("player 3 ready");
            pressDown.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5) && !player4)
        {
            player4 = true;
            Debug.Log("player 4 ready");
            press5.SetActive(false);
        }
    }
}
