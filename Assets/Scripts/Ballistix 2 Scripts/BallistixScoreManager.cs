using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;
using static BallistixGameSettings;

public class BallistixScoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BallistixGoalTracker[] goalTrackers;
    public BallistixPlayerSetup[] players;
    private int[] playerLives = new int[4];
    public BallistixPlayerUI[] playerUIs;
    public BallistixGameUI GameUI;

    public BallistixBall Ball;

    private int[] playerGoals = new int[4];
    private int[] playerGoalsUnadjusted = new int[4];




    void Start()
    {

        for (int i = 0; i < playerLives.Length; i++)
        {
            playerLives[i] = startingLives;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoalScore(int goalTrackerIndex)
    {
        playerLives[goalTrackerIndex]--;
        playerUIs[goalTrackerIndex].LoseLife();

        if (playerLives[goalTrackerIndex] <= 0)
        {
            Debug.Log($"Manager: {gameObject.name}");
            Debug.Log($"Array Length: {goalTrackers.Length}");

            for (int i = 0; i < goalTrackers.Length; i++)
            {
                Debug.Log($"goalTrackers[{i}] = {goalTrackers[i]}");
            }
            goalTrackers[goalTrackerIndex].EnableBlocker();
            PlayerIsOut(goalTrackerIndex);
            GameUI.Results(goalTrackerIndex);

        }
    }

    public void Shootout(int ballTrackerIndex, int goalTrackerIndex)
    {
        if (ballTrackerIndex == -1)
        {
            playerUIs[goalTrackerIndex].LosePoint();
            if (playerGoals[goalTrackerIndex] != 0)
            {
                playerGoals[goalTrackerIndex]--;
            }

            return;
        }
        if (ballTrackerIndex == goalTrackerIndex)
        {
            playerUIs[goalTrackerIndex].LosePoint();
            if (playerGoals[goalTrackerIndex] != 0)
            {
                playerGoals[goalTrackerIndex]--;
            }
            return;
        }
        if (ballTrackerIndex != goalTrackerIndex)
        {
            playerUIs[ballTrackerIndex].ScorePoint();
            playerGoals[ballTrackerIndex]++;
            playerGoalsUnadjusted[ballTrackerIndex]++;

            if (playerGoals[ballTrackerIndex] == goalTarget)
            {
                ShootOutEndGame();
                Debug.Log("Games ended");
            }
        }
    }

    public void ShootOutEndGame()
    {
        foreach (var player in players)
        {
            int i = players.Length - 1;

            while (i >= 0)
            {
                if (player.playerIndex == players[i].playerIndex)
                {
                    i--;
                    continue;
                }

                if (playerGoals[player.playerIndex] < playerGoals[players[i].playerIndex])
                {
                    player.playerPositon++;
                    i--;
                }
                else if (playerGoals[player.playerIndex] > playerGoals[players[i].playerIndex])
                {
                    i--;
                    continue;
                }
                else if (playerGoals[player.playerIndex] == playerGoals[players[i].playerIndex])
                {
                    if (playerGoalsUnadjusted[player.playerIndex] < playerGoalsUnadjusted[players[i].playerIndex])
                    {
                        player.playerPositon++;
                        i--;
                    }
                    else if (playerGoalsUnadjusted[player.playerIndex] > playerGoalsUnadjusted[players[i].playerIndex])
                    {
                        i--;
                        continue;
                    }
                    else if (playerGoalsUnadjusted[player.playerIndex] == playerGoalsUnadjusted[players[i].playerIndex])
                    {
                        i--;
                        continue;
                    }
                }
            }
        }

        // Gets a list of players in order based on player position
        List<BallistixPlayerSetup> results =
            players.OrderBy(player => player.playerPositon).ToList();

        GameUI.ShootOutResults(results);
    }


    public void PlayerIsOut(int goalTrackerIndex)
    {
        players[goalTrackerIndex].PlayerOut();
    }


     

}


