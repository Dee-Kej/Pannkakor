using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour {
    public GameObject playerPrefab;
    GameObject playerData;
    public GameObject[] spawnpoints;

	// Use this for initialization
	void Start () {
        playerData = GameObject.Find("Persistent PlayerData");

        Debug.Log(playerData.GetComponent<PlayerCount>().player1);
        if(playerData.GetComponent<PlayerCount>().player1)
        {
            Instantiate(playerPrefab, spawnpoints[0].transform.position, Quaternion.identity);
        }
        if (playerData.GetComponent<PlayerCount>().player2)
        {
            Instantiate(playerPrefab, spawnpoints[1].transform.position, Quaternion.identity);
        }
        if (playerData.GetComponent<PlayerCount>().player3)
        {
            Instantiate(playerPrefab, spawnpoints[2].transform.position, Quaternion.identity);
        }
        if (playerData.GetComponent<PlayerCount>().player4)
        {
            Instantiate(playerPrefab, spawnpoints[3].transform.position, Quaternion.identity);
        }
    }
	
}
