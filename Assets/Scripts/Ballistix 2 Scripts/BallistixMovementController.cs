using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class BallistixMovementController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rb;
    public float speed = 5f;
    private Vector2 movement;
    private float boostAmount = 2f;
    private float boostDuration = 5f;
    private BallistixPlayerSetup playerSetup;
        

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerSetup = GetComponent<BallistixPlayerSetup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMovement(Vector2 direction)
    {
        movement = direction;
        Debug.Log(movement);
    }

 
    private void FixedUpdate()
    {
      
        
            Vector3 move = new Vector3(movement.x, 0, movement.y);
            //move = move.normalized;
            rb.AddForce(move * speed);
        


    }

    public void ApplySpeedBoost()
    {
        StartCoroutine(SpeedBoostCoroutine(boostAmount, boostDuration));
    }

    public void ApplyBiggerPaddleBoost()
    {
        StartCoroutine(BiggerPaddleCoroutine(boostAmount, boostDuration));
    }

    public IEnumerator BiggerPaddleCoroutine(float boostAmount, float duration)
    {
        // Implement the logic for increasing the paddle size
        
        yield return new WaitForSeconds(duration); // Wait for the duration of the effect
        // Implement the logic for resetting the paddle size
    }



    public IEnumerator SpeedBoostCoroutine(float boostAmount, float duration)
    {
        speed *= boostAmount; // Increase the speed by the boost amount
        Debug.Log("Speed Boost Applied! New Speed: " + speed);
        yield return new WaitForSeconds(duration); // Wait for the duration of the boost
        speed /= boostAmount; // Reset the speed back to normal
        Debug.Log("Speed Boost Ended. Speed Reset to: " + speed);
    }
}
