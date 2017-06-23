using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    PlayerLook _lookComponent;
    PlayerMove _moveComponent;

    public bool isGrounded = true;
    bool isMoving = false;
    bool isJumping = false;

    public float speed;
    public float sensitivity;
    public float viewRange;
    public float jumpSpeed;
    public float jumpDistance;

    public bool useCustomGravity;
    public float customGravity;
    public bool IsGrounded
    {
        get { return isGrounded; }
    }

    public bool IsMoving
    {
        get { return isMoving; }
        set { isMoving = value; }
    }

    public bool IsJumping
    {
        get { return isJumping; }
    }
	// Use this for initialization
	void Start () {
        _lookComponent = GetComponentInChildren<PlayerLook>();
        _moveComponent = GetComponent<PlayerMove>();

        speed = speed > 0 ? speed : 5f;
        sensitivity = sensitivity > 0 ? sensitivity : 3f;
        viewRange = viewRange > 0 ? viewRange : 60f;
        jumpSpeed = jumpSpeed > 0 ? jumpSpeed : 6f;
        jumpDistance = jumpDistance > 0 ? jumpDistance : 2f;

        _lookComponent.Initialize(this);
        _moveComponent.Initialize(this);

        if(!useCustomGravity)
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
        else
        {
            if(customGravity == 0f)
            {
                customGravity = 9.81f;
            }
        }
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        /*
        if (!isGrounded)
        {
            if(useCustomGravity)
            {
                GetComponent<Rigidbody>().AddForce( ((-1f) * Vector3.up) * customGravity * GetComponent<Rigidbody>().mass);
            }
            
            
        }
        */
        Ray ray = new Ray(transform.position, new Vector3(0f, -1f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1.1f))
        {
            isGrounded = true;
            isJumping = false;
        }
        else
        {
            isGrounded = false;
        }
    }

    public void UpdateRotation(float yaw)
    {
        transform.localEulerAngles = new Vector3(0f, yaw, 0f); 
    }

    public void EnterJump()
    {
        //isGrounded = false;
        isJumping = true;
    }
}
