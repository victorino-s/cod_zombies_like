using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour {

    PlayerController controller;
    float targetHeigth;
    bool targetHeigthReached = false;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        bool movingLeft = Input.GetAxis("Horizontal") < 0f;
        bool movingRight = Input.GetAxis("Horizontal") > 0f;
        bool movingForward = Input.GetAxis("Vertical") > 0f;
        bool movingBackward = Input.GetAxis("Vertical") < 0f;
        bool jump = Input.GetAxis("Jump") != 0f;

        if(movingForward)
        {
            controller.IsMoving = true;
            GetComponent<Rigidbody>().velocity = controller.speed * transform.forward ;
        }
        else if(movingBackward)
        {
            controller.IsMoving = true;
            GetComponent<Rigidbody>().velocity = controller.speed * transform.forward * (-1f);
        }
        else if (movingRight)
        {
            controller.IsMoving = true;
            GetComponent<Rigidbody>().velocity = controller.speed * transform.right;
        }
        else if (movingLeft)
        {
            controller.IsMoving = true;
            GetComponent<Rigidbody>().velocity = controller.speed * transform.right * (-1f);
        }
        else
        {
            controller.IsMoving = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(controller.IsGrounded)
            {
                controller.EnterJump();
                targetHeigthReached = false;
                targetHeigth = transform.position.y + controller.jumpDistance;
                Elevate();
            }
        }

        if(controller.IsJumping)
        {
            if(!targetHeigthReached)
            {
                if(transform.position.y >= targetHeigth)
                {
                    targetHeigthReached = true;
                }
                Elevate();
            }
            else
            {
                Fall();
            }
        }
       
    }

    public void Initialize(PlayerController controller)
    {
        this.controller = controller;
    }

    void Elevate()
    {
        GetComponent<Rigidbody>().velocity += controller.jumpSpeed * Vector3.up;
    }

    void Fall()
    {
        if(controller.useCustomGravity)
        {
            GetComponent<Rigidbody>().velocity = controller.customGravity * (-1f) * Vector3.up;
        }
    }

}
