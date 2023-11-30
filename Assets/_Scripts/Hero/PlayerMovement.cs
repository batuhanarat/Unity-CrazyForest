using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    private float HorizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    public bool chargedJump = false;
    public float CrouchTime = 0f;

   
    //Take input
    void Update()
    {
        
            
       
        HorizontalMove = Input.GetAxis("Horizontal")* runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            
            animator.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            animator.SetBool("isCrouching", true);
            CrouchTime = 0f; // Reset crouch time when crouch starts

            crouch = true;
        }
        else if (Input.GetButton("Crouch"))
        {
            CrouchTime += Time.deltaTime; // Accumulate crouch time while crouching
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            animator.SetBool("isCrouching", false);
            CrouchTime = 0f; // Reset crouch time when crouch ends
            chargedJump = false;

            crouch = false; 
        
        
 
        }
        
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    
    
    //Move Character
    private void FixedUpdate()
    {
        controller.Move(HorizontalMove * Time.fixedDeltaTime, crouch,jump,false);
        jump = false;
    }
}