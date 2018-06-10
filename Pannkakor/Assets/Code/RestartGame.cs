using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

    GameObject playerData;

    void Start()
    {
        if (GameObject.Find("Persistent PlayerData") == true)
        {
            playerData = GameObject.Find("Persistent PlayerData");
        }
    }

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerData.GetComponent<PlayerCount>().player1 = false;
            playerData.GetComponent<PlayerCount>().player2 = false;
            playerData.GetComponent<PlayerCount>().player3 = false;
            playerData.GetComponent<PlayerCount>().player4 = false;
            SceneManager.LoadScene(0);
        }
    }
}
