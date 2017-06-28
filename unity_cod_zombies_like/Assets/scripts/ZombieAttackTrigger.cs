using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackTrigger : MonoBehaviour {

    Zombie zombie;
	// Use this for initialization
	void Start () {
        zombie = transform.parent.GetComponent<Zombie>();
	}
	
	void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            zombie.presenceInAttackZone = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            zombie.presenceInAttackZone = false;
        }
    }
}
