using UnityEngine;
using UnityEngine.UI;

public class FirstPersonController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float sprintMultiplier = 2.0f;
    public float stamina = 100.0f;
    public float staminaRecoveryRate = 5.0f;
    public float staminaDrainRate = 10.0f;
    public Slider staminaBar;
    float mouseSensitivity = 1.0f;
    public float jumpHeight = 2.0f;

    float verticalRotation = 0;
    public float upDownRange = 60.0f;

    float verticalVelocity = 0;

    // Add the variables for the camera effect
    public float bobbingSpeed = 0.18f;
    public float bobbingAmount = 0.2f;
    public float breathingSpeed = 0.05f;
    public float breathingAmount = 0.02f;
    public bool isCameraEffectEnabled = true;

    private float timer = 0f;
    private Vector3 originalPosition;
    private float movement;
    private bool isSprinting = false;

    CharacterController characterController;

    public GameObject menuPanel;
    public GameObject optionsPanel;

    public void SetMouseSensitivity(float sensitivity)
    {
        mouseSensitivity = sensitivity;
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        mouseSensitivity = PlayerPrefs.GetFloat("Mouse Sensitivity", 1.0f);
        originalPosition = Camera.main.transform.localPosition;
    }

    void Update()
    {
        if (menuPanel.activeSelf || optionsPanel.activeSelf)
        {
            // Darken the stamina bar if the menu or options panel is active
            staminaBar.interactable = false;
        }
        else
        {
            // Restore the normal color of the stamina bar if the menu and options panel are not active
            staminaBar.interactable = true;
        }

        if (!menuPanel.activeSelf && !optionsPanel.activeSelf)
        {
            // Rotate player based on mouse movement
            float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
            transform.Rotate(0, rotLeftRight, 0);

            verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
            Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        }
        
        // Check if the player is sprinting
        isSprinting = Input.GetKey(KeyCode.LeftShift) && stamina > 0;

        // Calculate the movement speed
        float speed = movementSpeed;
        if (isSprinting)
        {
            speed *= sprintMultiplier;
        }

        // Drain stamina if the player is sprinting
        if (isSprinting)
        {
            stamina -= staminaDrainRate * Time.deltaTime;
        }
        else
        {
            // Recover stamina if the player is not sprinting
            stamina += staminaRecoveryRate * Time.deltaTime;
        }

        // Clamp the stamina value between 0 and 100
        stamina = Mathf.Clamp(stamina, 0, 100);

        // Update the stamina bar
        staminaBar.value = stamina;

        // Calculate the movement direction based on WASD input
        float forward = Input.GetAxis("Vertical");
        float right = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(right, 0, forward);
        direction = transform.rotation * direction;

        // Calculate the movement vector
        Vector3 movement = direction * speed;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded && Input.GetButton("Jump"))
        {
            verticalVelocity = jumpHeight;
        }

        if (isCameraEffectEnabled) 
        {
            // Add the camera effects
            if (movement.magnitude > 0)
            {
            movement *= bobbingAmount;
            BobbingEffect();
            }
            else
            {
            BreathingEffect();
            }
        }
        

        // Add the vertical velocity to the movement vector
        movement += new Vector3(0, verticalVelocity, 0);

        // Move the character controller
        characterController.Move(movement * Time.deltaTime);
    }

    private void BreathingEffect()
    {
        float waveslice = 0f;
        waveslice = Mathf.Sin(timer);
        timer = timer + breathingSpeed;
        if (timer > Mathf.PI * 2)
        {
            timer = timer - (Mathf.PI * 2);
        }
        float translateChange = waveslice * breathingAmount;
        Camera.main.transform.localPosition = originalPosition + new Vector3(0f, translateChange, 0f);
    }

    private void BobbingEffect()
    {
        float waveslice = Mathf.Sin(timer);
        timer = timer + bobbingSpeed;
        if (timer > Mathf.PI * 2)
        {
            timer = timer - (Mathf.PI * 2);
        }
        float translateChange = waveslice * bobbingAmount;
        float sprintMultiplier = 1f;
        if (isSprinting)
        {
            sprintMultiplier = 2f;
        }
        Camera.main.transform.localPosition = originalPosition + new Vector3(0f, translateChange, 0f) * sprintMultiplier;
    }

    public void toggleBobbing()
    {
        isCameraEffectEnabled = !isCameraEffectEnabled;
        movementSpeed = isCameraEffectEnabled ? movementSpeed *= 10 : movementSpeed /= 10;
    }
}

           
