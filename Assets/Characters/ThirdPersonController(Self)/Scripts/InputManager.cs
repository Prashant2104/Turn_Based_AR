using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    ThirdPersonPlayerController playerControls;
    PlayerMotion playerMotion;
    AnimatorManager animatorManager;
    
    [SerializeField] Vector2 movementInput;
    [SerializeField] Vector2 cameraInput;

    public float moveAmount;

    public float VerticalInput;
    public float HorizontalInput;

    public bool SprintInput;
    public bool JumpInput;
    public bool CanJump;

    public float cameraInputX;
    public float cameraInputY;

    //public Inventory Stats;
    //public GameManager Manager;

    public ParticleSystem Heal;
    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerMotion = GetComponent<PlayerMotion>();
    }

    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new ThirdPersonPlayerController();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

            playerControls.PlayerActions.Sprint.performed += i => SprintInput = true;
            playerControls.PlayerActions.Sprint.canceled += i => SprintInput = false;

            playerControls.PlayerActions.Jump.performed += i => JumpInput = true;

            //playerControls.UI.ShowStats.performed += i => Stats.EnableStats();
            //playerControls.UI.ShowStats.canceled += i => Stats.DisableStats();

            //playerControls.UI.Heal.performed += i => HealVFX();

            //playerControls.UI.Pause.performed += i => Manager.PauseMenu();
        }
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    public void HandleAllInput()
    {
        HandleMovementInput();
        HandleSprintInput();
        if(CanJump)
            HandleJumpInput();
    }
    private void HandleMovementInput()
    {
        VerticalInput = movementInput.y;
        HorizontalInput = movementInput.x;

        cameraInputY = cameraInput.y;
        cameraInputX = cameraInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(HorizontalInput) + Mathf.Abs(VerticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount, playerMotion.IsSprinting);
    }
    private void HandleSprintInput()
    {
        if (SprintInput && moveAmount > 0.5f)
            playerMotion.IsSprinting = true;
        else
            playerMotion.IsSprinting = false;
    }

    private void HandleJumpInput()
    {
        if (JumpInput)
        {
            JumpInput = false;
            playerMotion.HandleJump();
        }
    }

    /*public void HealVFX()
    {
        if(Stats.HealPotion >= 1)
        {
            Heal.Play();
            StartCoroutine(StopVFX());
        }
        Stats.HealButton();
    }*/
    IEnumerator StopVFX()
    {
        yield return new WaitForSeconds(1.5f);
        Heal.Stop();
    }
}