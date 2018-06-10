using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public PlayerCount playerScript;
	// Use this for initialization
	void Start () {
        StartCoroutine(ResetPlayers());
	}
	
	// Update is called once per frame
	void Update () {
        if ((playerScript.player1 || playerScript.player2 || playerScript.player3 || playerScript.player4) && Input.GetButtonDown("Start"))
        {

            SceneManager.LoadScene(1);
        }
	}

    IEnumerator ResetPlayers()
    {
        yield return new WaitForSeconds(2f);
        playerScript.player1 = false;
        playerScript.player2 = false;
        playerScript.player3 = false;
        playerScript.player4 = false;
    }
}
