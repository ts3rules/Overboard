using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class BallistixScoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BallistixGoalTracker[] goalTrackers;
    public BallistixPlayerSetup[] players;
    private int[] playerLives = new int[4];
    public BallistixPlayerUI[] playerUIs;
    public BallistixGameUI GameUI;


    void Start()
    {
       
        for (int i = 0; i < playerLives.Length; i++)
        {
            playerLives[i] = BallistixGameSettings.startingLives;
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

    public void PlayerIsOut(int goalTrackerIndex)
    {
        players[goalTrackerIndex].PlayerOut();
    }


     

}


