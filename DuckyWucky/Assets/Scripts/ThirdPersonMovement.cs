﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float turnSmothTime = 0.1f;
    float turnSmoothVelocity;


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            //Atan2 turns the player to face the diraction was have inpted with the movement keys
            //Rad2Deg converts the units into degrees
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }    
    }

    //Gravity needs to be applied, but only while the character is airborne. Have a seperate variable that tracks the current vertical speed, then set it equal to 0 or gravity depending on if it is or
    //is not grounded. The just constantly plug in the vertical speed into the moveDir. Bonus points if gravity gets stronger, the longer the player isn't grounded.
}
