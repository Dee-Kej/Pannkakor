using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

    public GameObject playerData;

    void Start()
    {
        if (GameObject.Find("Persistent PlayerData") == true)
        {
            playerData = GameObject.Find("Persistent PlayerData");
        }
        StartCoroutine(ResetPlayers());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(GameObject.Find("Persistent PlayerData"));
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator ResetPlayers()
    {
        yield return new WaitForSeconds(2f);
        playerData.GetComponent<PlayerCount>().player1 = false;
        playerData.GetComponent<PlayerCount>().player2 = false;
        playerData.GetComponent<PlayerCount>().player3 = false;
        playerData.GetComponent<PlayerCount>().player4 = false;
    }
}
