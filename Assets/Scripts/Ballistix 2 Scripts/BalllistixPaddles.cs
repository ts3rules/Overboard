using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls; 

public class BalllistixPaddles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Paddle; // Reference to the paddle object
    Rigidbody rb;
    public float speed = 5f; // Speed at which the paddle hits the ball 
    private InputAction powerShot;
    public bool isPowerShotActive = false; // Flag to track if the power shot is active
   


    void Start()
    {
        rb = Paddle.GetComponent<Rigidbody>();
        powerShot = new InputAction("PowerShot");
        powerShot.AddBinding("<Keyboard>/space");
        powerShot.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerShot.WasPressedThisFrame())
        {
            Debug.Log("Power Shot!");
            OnPowerShot();
        }

    }

    private void FixedUpdate()
    {
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (isPowerShotActive)
            {
                speed *= 2; // Double the speed for the power shot
            }
            // Handle collision with the player
            Rigidbody ballrb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            ballrb.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
        }
        
    }

    void OnPowerShot()
    {
        // This method will be called when the player presses the space key
        // You can add logic here to perform a power shot, such as increasing the force applied to the ball
        Debug.Log("Power Shot Activated!");
        isPowerShotActive = true;

    }

    void Jump(InputValue value)
    {
        // This method will be called when the player presses the jump key (space by default)
        // You can add logic here to make the paddle jump, such as applying an upward force
        if (value.isPressed)
        {
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            Debug.Log("Paddle Jumped!");
        }
    }

    void onAttack(InputValue value)
    {
        // This method will be called when the player performs an attack action
        // You can add logic here to perform an attack, such as applying a force to the ball or triggering an animation
        Debug.Log("Attack Performed!");
    }
}
