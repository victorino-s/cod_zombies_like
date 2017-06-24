using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(PlayerController))]
public class PlayerMove : MonoBehaviour
{

    PlayerController controller;
    bool isJumping = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && controller.IsGrounded)
        {
            GetComponent<Rigidbody>().AddForce(controller.jumpForce * Vector3.up, ForceMode.Impulse);
        }


        
        if (Input.GetButton("Forward"))
        {
            controller.IsMoving = true;
            GetComponent<Rigidbody>().AddForce(controller.speed * transform.forward, ForceMode.VelocityChange);

        }
        else if (Input.GetButton("Backward"))
        {
            controller.IsMoving = true;
            GetComponent<Rigidbody>().AddForce(controller.speed * transform.forward * (-1f), ForceMode.VelocityChange);
        }
      /*  else
        {
            controller.IsMoving = false;
            Vector3 vel = GetComponent<Rigidbody>().velocity;
            vel = new Vector3(0, vel.y, 0);
            GetComponent<Rigidbody>().velocity = vel;
        }*/

        if (Input.GetButton("Right"))
        {
            controller.IsMoving = true;
            GetComponent<Rigidbody>().AddForce(controller.speed * transform.right, ForceMode.VelocityChange);
        }
        else if (Input.GetButton("Left"))
        {
            controller.IsMoving = true;
            GetComponent<Rigidbody>().AddForce(controller.speed * transform.right * (-1f), ForceMode.VelocityChange);
        }/*
        else
        {
            controller.IsMoving = false;
            Vector3 vel = GetComponent<Rigidbody>().velocity;
            vel = new Vector3(0, vel.y, 0);
            GetComponent<Rigidbody>().velocity = vel;
        }*/

        // Apply correct maxSpeed
        Vector3 v = GetComponent<Rigidbody>().velocity;
        GetComponent<Rigidbody>().velocity = new Vector3(Vector3.ClampMagnitude(v, controller.maxSpeed).x, v.y, Vector3.ClampMagnitude(v, controller.maxSpeed).z);




        /*
         * Cette partie bug car le GetButtonDown est bloquant et ducoup l'objet redescent par a coups lors des sauts (atterissage)
         * De meme lorsque que je faisais : bool isMovingForward = Input.GetAxis("Vertical") > 0;
         * De plus , dans le else, le fait de mettre la vélocité à 0 annule la vitesse de chute
         * 
        if (Input.GetButtonDown("Forward"))
        {
            controller.IsMoving = true;
            GetComponent<Rigidbody>().AddForce(controller.speed * transform.forward, ForceMode.Acceleration);

        }
        else if (Input.GetButtonDown("Backward"))
        {
            controller.IsMoving = true;
            GetComponent<Rigidbody>().AddForce(controller.speed * transform.forward * (-1f), ForceMode.Force);
        }
        else if (Input.GetButtonDown("Right"))
        {
            controller.IsMoving = true;
            GetComponent<Rigidbody>().AddForce(controller.speed * transform.right, ForceMode.Force);
        }
        else if (Input.GetButtonDown("Left"))
        {
            controller.IsMoving = true;
            GetComponent<Rigidbody>().AddForce(controller.speed * transform.right * (-1f), ForceMode.Force);
        }
        else
        {
            controller.IsMoving = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        */

    }

    public void Initialize(PlayerController controller)
    {
        this.controller = controller;
    }
}
