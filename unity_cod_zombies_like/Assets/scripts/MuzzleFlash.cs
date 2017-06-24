using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour {

    MeshRenderer muzzleFlash;
    Light muzzleLight;
	// Use this for initialization
	void Start () {
        muzzleFlash.enabled = false;
        muzzleLight.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        muzzleFlash.GetComponent<Renderer>().enabled = true;
        muzzleLight.enabled = true;
        Invoke("StopShoot", 0.2f);
    }

    void StopShoot()
    {
        muzzleFlash.GetComponent<Renderer>().enabled = true;
        muzzleLight.enabled = true;
    }
}
