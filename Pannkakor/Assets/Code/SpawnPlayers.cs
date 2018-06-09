﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour {
    public GameObject playerPrefab;
    GameObject playerData;
    public GameObject[] spawnpoints;

	// Use this for initialization
	void Start () {
        if(GameObject.Find("Persistent PlayerData") == true)
        {
            playerData = GameObject.Find("Persistent PlayerData");
        }
        else
        {
            return;
        }
        if (playerData != null)
        {
            Debug.Log(playerData.GetComponent<PlayerCount>().player1);
            if (playerData.GetComponent<PlayerCount>().player1)
            {
                GameObject player1;
                player1 = Instantiate(playerPrefab, spawnpoints[0].transform.position, Quaternion.identity);
                player1.tag = "Player1";
            }
            if (playerData.GetComponent<PlayerCount>().player2)
            {
                GameObject player2;
                player2 = Instantiate(playerPrefab, spawnpoints[1].transform.position, Quaternion.identity);
                player2.tag = "Player2";
            }
            if (playerData.GetComponent<PlayerCount>().player3)
            {
                GameObject player3;
                player3 = Instantiate(playerPrefab, spawnpoints[2].transform.position, Quaternion.identity);
                player3.tag = "Player3";
            }
            if (playerData.GetComponent<PlayerCount>().player4)
            {
                GameObject player4;
                player4 = Instantiate(playerPrefab, spawnpoints[3].transform.position, Quaternion.identity);
                player4.tag = "Player4";
            }
        }
    }
	
}
