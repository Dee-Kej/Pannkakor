using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public PlayerCount playerScript;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
        if ((playerScript.player1 || playerScript.player2 || playerScript.player3 || playerScript.player4) && Input.GetButtonDown("Start"))
        {

            SceneManager.LoadScene(1);
        }
	}

    
}
