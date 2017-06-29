using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GlobalManager : NetworkManager {

    public Material[] player_materials = new Material[4];
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        var player = (GameObject)GameObject.Instantiate(playerPrefab, GetStartPosition().position, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        switch(numPlayers)
        {
            case 1:
                player.GetComponent<MeshRenderer>().material = player_materials[0];
                break;
            case 2:
                player.GetComponent<MeshRenderer>().material = player_materials[1];
                break;
            case 3:
                player.GetComponent<MeshRenderer>().material = player_materials[2];
                break;
            case 4:
                player.GetComponent<MeshRenderer>().material = player_materials[3];
                break;
            default:
                player.GetComponent<MeshRenderer>().material = player_materials[0];
                break;
        }
    }
}
