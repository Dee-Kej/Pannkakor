using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour {

   

    public GameObject playerPrefab;
    GameObject playerData;
    public GameObject[] spawnpoints;
    public Sprite[] playerSprites;
    public Vector3 playerScale;
  public  GameObject player1, player2, player3, player4;

   

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

        playerPrefab.transform.localScale = playerScale;

        if (playerData != null)
        {
            Debug.Log(playerData.GetComponent<PlayerCount>().player1);
            if (playerData.GetComponent<PlayerCount>().player1)
            {
                player1 = Instantiate(playerPrefab, spawnpoints[0].transform.position, Quaternion.identity);
                player1.tag = "Player1";
                player1.GetComponent<SpriteRenderer>().sprite = playerSprites[0];
            }
            if (playerData.GetComponent<PlayerCount>().player2)
            {
                player2 = Instantiate(playerPrefab, spawnpoints[1].transform.position, Quaternion.identity);
                player2.tag = "Player2";
                player2.GetComponent<SpriteRenderer>().sprite = playerSprites[1];
            }
            if (playerData.GetComponent<PlayerCount>().player3)
            {
                player3 = Instantiate(playerPrefab, spawnpoints[2].transform.position, Quaternion.identity);
                player3.tag = "Player3";
                player3.GetComponent<SpriteRenderer>().sprite = playerSprites[2];
            }
            if (playerData.GetComponent<PlayerCount>().player4)
            {
                player4 = Instantiate(playerPrefab, spawnpoints[3].transform.position, Quaternion.identity);
                player4.tag = "Player4";
                player4.GetComponent<SpriteRenderer>().sprite = playerSprites[3];
            }
        }
    }
}
