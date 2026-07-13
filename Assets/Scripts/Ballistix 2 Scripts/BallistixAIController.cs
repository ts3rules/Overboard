using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Experimental.GraphView.GraphView;


public class BallistixAIController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject ai;
    private BallistixMovementController MovementController;
    public GameObject goal;
    public List<GameObject> balls = new List<GameObject>();
    private Vector3 homeOffset = new Vector3(3, 3, 3);
    public GameObject home;
    void Start()
    {
        // gets the movement controller for moving the ai 

        MovementController = GetComponent<BallistixMovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] foundBalls = GameObject.FindGameObjectsWithTag("Ball");
        balls = new List<GameObject>(foundBalls);
        if (balls != null)
        {
            findNearestBall();
            //Vector3 direction = home.transform.position - transform.position;
            //Vector2 movement = new Vector2(direction.x, direction.z);
            // Debug.Log("Moving Home");
            // MovementController.SetMovement(movement);
        }

        //find game objects with the tag ball

    }

    void Safezone()
    {
        float distanceToHome = Vector3.Distance(transform.position, home.transform.position);
        if (distanceToHome < 6)
        {
            return;
        }
        else
        {
            Vector3 direction = home.transform.position - transform.position;
            Vector2 movement = new Vector2(direction.x, direction.z);
            MovementController.SetMovement(movement);
        }
    }

    void ChaseBall(GameObject targetBall)
    {
        Vector3 direction =
            targetBall.transform.position -
            transform.position;

        Vector2 movement =
            new Vector2(direction.x, direction.z);

        MovementController.SetMovement(movement);
    }

    void PredictBall(GameObject targetball)
    {
        Rigidbody rb = targetball.GetComponent<Rigidbody>();
        Vector3 prediction = rb.linearVelocity * 0.2f;
        Vector3 futurePosition = targetball.transform.position + prediction;
        Vector3 direction = futurePosition - transform.position;
        Vector2 movement = new Vector2(direction.x, direction.z);

        MovementController.SetMovement(movement);
    }

    void findNearestBall()
    {
        float nearestBall = 9999f; // Initialize with a large value to ensure it gets updated with the actual nearest player position
        GameObject nearestBallObject = null; // To keep track of the nearest player GameObject

        foreach (GameObject ball in balls)

        {

            if (ball == null)
            {
                continue; // Skip if the enemy GameObject is null
            }



            float distanceToBall = Vector3.Distance(transform.position, ball.transform.position);

            if (distanceToBall < nearestBall)
            {
                nearestBall = distanceToBall;
                nearestBallObject = ball;
            }


            // do AI logic here
        }
        if (nearestBallObject != null)
        {
            //ChaseBall(nearestBallObject);

            Rigidbody rb = nearestBallObject.GetComponent<Rigidbody>();
            Vector3 dangerous = (goal.transform.position - nearestBallObject.transform.position).normalized;
            Vector3 ballDirection = rb.linearVelocity.normalized;
            float dangerLevel = Vector3.Dot(ballDirection, dangerous);

            if (dangerLevel > 0f)
            {
                PredictBall(nearestBallObject);
            }
            else
            {
                Safezone();
            }
        }
    }
}
       

        
    



    


