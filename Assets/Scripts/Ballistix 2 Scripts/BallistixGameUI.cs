using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BallistixGameUI : MonoBehaviour
{
    public BallistixPlayerSetup[] players;

    [SerializeField] private TextMeshProUGUI FirstValue;
    [SerializeField] private TextMeshProUGUI SecondValue;
    [SerializeField] private TextMeshProUGUI ThirdValue;
    [SerializeField] private TextMeshProUGUI ForthValue;

    [SerializeField] private Button resultsButton;

    public Camera EndCam;

    private List<int> results = new List<int>();

    private void Awake()
    {
        EndCam.enabled = false;
    }

    public void Results(int playerNumber)
    {
        Debug.Log($"Results called for playerNumber: {playerNumber}");
        Debug.Log($"Current results count: {results.Count}");

        // Stop once three players have been eliminated
        if (results.Count >= 3)
            return;

        int playerIndex = players[playerNumber].playerIndex;

        // Prevent the same player being added more than once
        if (results.Contains(playerIndex))
        {
            Debug.Log($"Player {playerIndex} is already in results.");
            return;
        }

        results.Add(playerIndex);

        Debug.Log($"Player {playerIndex} eliminated.");

        if (results.Count == 3)
        {
            int winner = GetWinner();

            Debug.Log($"Winner is Player {winner}");

            // Check player array
            for (int i = 0; i < players.Length; i++)
            {
                Debug.Log(
                    $"players[{i}] = {players[i].name}, " +
                    $"playerIndex = {players[i].playerIndex}"
                );
            }

            // Check elimination order
            for (int i = 0; i < results.Count; i++)
            {
                Debug.Log($"results[{i}] = Player {results[i]}");
            }

            Debug.Log($"RESULT ORDER: {string.Join(", ", results)}");
            Debug.Log($"WINNER: {winner}");

            // Activate end-game camera
            EndCam.enabled = true;
            

            // Results are stored in elimination order,
            // so display them in reverse order.
            FirstValue.text = players[winner].name;
            SecondValue.text = players[results[2]].name;
            ThirdValue.text = players[results[1]].name;
            ForthValue.text = players[results[0]].name;
            StartCoroutine(EnableResultsButton());
        }
    }


    private int GetWinner()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (!results.Contains(players[i].playerIndex))
            {
                return players[i].playerIndex;
            }
        }

        return -1;


    }

    private IEnumerator EnableResultsButton()
    {
        resultsButton.interactable = false;

        yield return new WaitForSeconds(5f);

        resultsButton.interactable = true;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Ballistix 2 Menu");
    }


}