using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;
using UnityEngine.Rendering;

public class PlayerManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> players = new List<GameObject>();
    public TextMeshProUGUI winnerMessage;
    public List<string> eliminatedPLayers = new List<string>();
    public TMP_Text firstPlaceText;
    public TMP_Text secondPlaceText;
    public TMP_Text thirdPlaceText;
    public TMP_Text fourthPlaceText;
    public GameObject standingsScreen;
    public GameObject pauseScreen;
    void Start()
    {
        GameObject[] playerCount = GameObject.FindGameObjectsWithTag("Player");
        players = new List<GameObject>(playerCount);
        if (winnerMessage != null) winnerMessage.text = "";
    }

    // Update is called once per frame
    void Update()
    {


        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (Time.timeScale == 0f)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }


        // 1. Instantly sweep the list and remove anything that was Destroy()'ed
        //players.RemoveAll(player => player == null);
        foreach (GameObject player in players)
        {
            if (player == null)
            {
                continue;
            }
            AiController enemyAI = player.GetComponent<AiController>();
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null && playerController.isDead)
            {
                eliminatedPLayers.Add(player.name);
                players.Remove(player);
                
                break; // Exit the loop after modifying the list to avoid issues
            }
            else if (enemyAI != null && enemyAI.isDead)
            {
                eliminatedPLayers.Add(player.name);
                players.Remove(player);

                break; // Exit the loop after modifying the list to avoid issues
            }
        }

        // 2. Now check the true remaining count
        if (players.Count == 1)
            {

                if (winnerMessage != null)
                {
                winnerMessage.text = players[0].name + " wins!";
                eliminatedPLayers.Add(players[0].name);
                }
            Debug.Log(players[0].name + " wins!");
            Debug.Log(eliminatedPLayers.Count + " players were eliminated.");
            // Stop the update loop from spamming the console
            Time.timeScale = 0.5f;
                enabled = false;
                Invoke("Standings", 2f);

             }
    

    }

    private void Standings()
    {
        if (eliminatedPLayers.Count > 0)
        {
            firstPlaceText.text = "1st: " + eliminatedPLayers[eliminatedPLayers.Count - 1];
        }
        if (eliminatedPLayers.Count > 1)
        {
            secondPlaceText.text = "2nd: " + eliminatedPLayers[eliminatedPLayers.Count - 2];
        }
        if (eliminatedPLayers.Count > 2)
        {
            thirdPlaceText.text = "3rd: " + eliminatedPLayers[eliminatedPLayers.Count - 3];
        }
        if (eliminatedPLayers.Count > 3)
        {
            fourthPlaceText.text = "4th: " + eliminatedPLayers[eliminatedPLayers.Count - 4];
        }
        standingsScreen.SetActive(true);
        Invoke("MainMenu", 4f);

    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Knockout Menu");
    }

     void PauseGame()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResumeGame();
        }

    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }      
    


}
