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
        
        

    }

    private void FixedUpdate()
    {
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
         
            // Handle collision with the player
            Rigidbody ballrb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            ballrb.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
        }
        
    }
}
