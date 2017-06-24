using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerLook : MonoBehaviour {

    PlayerController controller;

    float yaw = 0.0f;
    float pitch = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        yaw += controller.sensitivity * Input.GetAxis("Mouse X");
        pitch -= controller.sensitivity * Input.GetAxis("Mouse Y");

        pitch = Mathf.Clamp(pitch, -controller.viewRange, controller.viewRange); // Clamp camera vertical rotation

        transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);
        controller.UpdateRotation(yaw);
    }

    public void Initialize(PlayerController controller) 
    {
        this.controller = controller;
    }
}
