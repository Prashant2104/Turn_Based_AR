using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerMotion playerMotion;
    Animator anim;

    public bool isInteracting;
    //public CameraManager cameraManager;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerMotion = GetComponent<PlayerMotion>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        inputManager.HandleAllInput();
    }
    private void FixedUpdate()
    {
        playerMotion.HandleAllMovement();
    }
    private void LateUpdate()
    {
        //cameraManager.HandleAllCameraMovement();
        isInteracting = anim.GetBool("isInteracting");
        playerMotion.IsJumping = anim.GetBool("isJumping");
        anim.SetBool("isGrounded", playerMotion.IsGrounded);
    }
}
