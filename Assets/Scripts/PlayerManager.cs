using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class PlayerManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> players = new List<GameObject>();
    public TextMeshProUGUI winnerMessage;
    void Start()
    {
        GameObject[] playerCount = GameObject.FindGameObjectsWithTag("Player");
        players = new List<GameObject>(playerCount);
        if (winnerMessage != null) winnerMessage.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
        
            // 1. Instantly sweep the list and remove anything that was Destroy()'ed
            players.RemoveAll(player => player == null);

            // 2. Now check the true remaining count
            if (players.Count == 1)
            {

                if (winnerMessage != null)
                {
                winnerMessage.text = players[0].name + " wins!";
                }
            Debug.Log(players[0].name + " wins!");

                // Stop the update loop from spamming the console
                Time.timeScale = 0.5f;
                enabled = false;
                Invoke("MainMenu", 2f);





             }

    }

    private void MainMenu()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Knockout Menu");
    }


}
