using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCount : MonoBehaviour {

    public bool player1, player2, player3, player4;
    public GameObject pressS, pressK, pressDown, press5;
    //public bool isStartScene = false;

	void Start () {
        DontDestroyOnLoad(gameObject);

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            pressS = GameObject.Find("P1 join");
            pressK = GameObject.Find("P2 join");
            pressDown = GameObject.Find("P3 join");
            press5 = GameObject.Find("P4 join");
        }

        player1 = player2 = player3 = player4 = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetButtonDown("Fire1") || Input.GetButtonDown("Grab1") && !player1)
            {
                player1 = true;
                //Debug.Log("player 1 ready");
                if (pressS != null)
                {
                    pressS.SetActive(false);
                }
            }

            else if (Input.GetKeyDown(KeyCode.K) || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Grab2") && !player2)
            {
                player2 = true;
                //Debug.Log("player 2 ready");
                if (pressK != null)
                {
                    pressK.SetActive(false);
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetButtonDown("Fire3") || Input.GetButtonDown("Grab3") && !player3)
            {
                player3 = true;
                //Debug.Log("player 3 ready");
                if (pressDown != null)
                {
                    pressDown.SetActive(false);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetButtonDown("Fire4") || Input.GetButtonDown("Grab4") && !player4)
            {
                player4 = true;
                //Debug.Log("player 4 ready");
                if (press5 != null)
                {
                    press5.SetActive(false);
                }
            }
        }
    }
}
