using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerDebug : NetworkBehaviour {

    public Vector3 _zombieSpawnPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    
		if(Input.GetKeyDown(KeyCode.F1))
        {
            CmdInvokeZombie();
        }
	}

    [Command]
    void CmdInvokeZombie()
    {
        GameObject zombie = Instantiate(GameObject.Find("Temp_NetworkManager").GetComponent<GlobalManager>().spawnPrefabs[0], _zombieSpawnPoint, Quaternion.identity);
        NetworkServer.Spawn(zombie);
    }
}
