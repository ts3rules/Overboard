using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class aiController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private PlayerController playerController;
    private Vector3 middlePoint = new Vector3(0, 3, 0);
    public List<GameObject> players = new List<GameObject>();
    void Start()
    {
       // GameObject[] foundPlayers = GameObject.FindGameObjectsWithTag("Player");

        // 2. Automatically feed those objects into your List
       // players = new List<GameObject>(foundPlayers);
        Debug.Log("Number of players found: " + players.Count);
        //int totalPlayers = players.Count;
        playerController = GetComponent<PlayerController>();
        Vector3 direction = middlePoint - transform.position;
        direction = direction.normalized;
        Vector2 movement = new Vector2(direction.x, direction.z);
        playerController.SetMovement(movement);
        //findNearestPLayer(players[players.Count]);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = middlePoint - transform.position;
    }

    void ChasePlayer()
    {
        Vector3 direction = playerController.transform.position - transform.position;
        direction = direction.normalized;
        Vector2 movement = new Vector2(direction.x, direction.z);
        playerController.SetMovement(movement);
    }  
   
    void findNearestPLayer(GameObject player)
    {
        float nearestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;

        foreach (GameObject p in players)
        {
            float distance = Vector3.Distance(transform.position, p.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestPlayer = p;
            }
        }

        if (nearestPlayer != null)
        {
            playerController.SetMovement(new Vector2(nearestPlayer.transform.position.x, nearestPlayer.transform.position.z));
        }
    }
}

