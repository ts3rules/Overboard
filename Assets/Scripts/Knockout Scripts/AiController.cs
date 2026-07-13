using System.Collections.Generic;
using TMPro;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class AiController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float dangerZoneXUpper = 8f;
    private float dangerZoneXLower = -3f;
    private float dangerZoneZUpper = 3f;
    private float dangerZoneZLower = -8f;
    private bool inDangerZone = false;
    public bool onFloor = true;
    private float recoveryTimer = 0f;
    // the egdes of the game area to make sure the ai doesn't go out of bounds
    private PlayerController playerController;
    private Vector3 middlePoint = new Vector3(0, 3, 0);
    public List<GameObject> players = new List<GameObject>();
    public bool isDead = false;

    void Start()
    {
        GameObject[] foundPlayers = GameObject.FindGameObjectsWithTag("Player");

        //2. Automatically feed those objects into your List
        players = new List<GameObject>(foundPlayers);
        Debug.Log("Number of players found: " + players.Count);
        //int totalPlayers = players.Count;
        playerController = GetComponent<PlayerController>();
        Vector3 direction = middlePoint - transform.position;
        direction = direction.normalized;
        Vector2 movement = new Vector2(direction.x, direction.z);
        Debug.Log(playerController);

        //playerController.SetMovement(movement);
        //findNearestPLayer(players[players.Count]);
    }

    // Update is called once per frame
    void Update()
    {
        if (recoveryTimer > 0)
        {
            recoveryTimer -= Time.deltaTime;
            StayInBounds();
        }
        else
        {
            if (StayInBounds())
            {
                recoveryTimer = 1f;
            }
            else
            {
                findNearestPLayer();
            }
        }
    }

    void ChasePlayer()
    {
        Vector3 direction = playerController.transform.position - transform.position;
        direction = direction.normalized;
        Vector2 movement = new Vector2(direction.x, direction.z);
        playerController.SetMovement(movement);
    }

    // This method finds the nearest player and sets the movement towards that player
    void findNearestPLayer()
    {
        float nearestPlayer = 9999f; // Initialize with a large value to ensure it gets updated with the actual nearest player position
        GameObject nearestPlayerObject = null; // To keep track of the nearest player GameObject

        foreach (GameObject enemy in players)

        {

            if (enemy == null)
            {
                continue; // Skip if the enemy GameObject is null
            }

            if (enemy == gameObject)
            {
                continue;
            }

            AiController enemyAI = enemy.GetComponent<AiController>();
            PlayerController playerController = enemy.GetComponent<PlayerController>();

            if (enemyAI != null)
            {
                if (enemyAI.onFloor != true)
                {
                    continue;
                }
            }
            else if (playerController != null)
            {
                if (playerController.onFloor != true)
                {
                    continue;
                }
            }
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < nearestPlayer)
            {
                nearestPlayer = distanceToEnemy;
                nearestPlayerObject = enemy;
            }


            // do AI logic here
        }
        if (nearestPlayerObject != null)
        {
            Vector3 direction = nearestPlayerObject.transform.position - transform.position;
            Vector2 movement = new Vector2(direction.x, direction.z);
            playerController.SetMovement(movement);
        }
    }



    void ChasePLayerOne()
    {
        GameObject playerOne = GameObject.Find("Player one");
        if (playerOne != null)
        {
            Vector3 direction = playerOne.transform.position - transform.position;
            Vector2 movement = new Vector2(direction.x, direction.z);
            playerController.SetMovement(movement);
            Debug.Log("Chasing Player One");
        }
    }

    bool StayInBounds()
    {
        Vector2 movement = Vector2.zero;

        if (transform.position.x > dangerZoneXUpper)
        {
            movement.x = -1;
        }

        else if (transform.position.x < dangerZoneXLower)
        {
            movement.x = 1;
        }

        if (transform.position.z > dangerZoneZUpper)
        {
            movement.y = -1;
        }

        else if (transform.position.z < dangerZoneZLower)
        {
            movement.y = 1;
        }

        if (movement != Vector2.zero)
        {
            movement = movement.normalized;
            playerController.SetMovement(movement);
            return true;
        }

        return false;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = false;
        }

    }
}

