using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using static BallistixGameSettings;

public class BallistixGoalTracker : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BallistixScoreManager scoreManager;
    public GameObject goalTracker;
    public GameObject goalBlocker;
    public int goalTrackerIndex;

    public BallistixBall ball;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (startingMode == GameMode.Classic)
            {
                scoreManager.GoalScore(goalTrackerIndex);
            }
            if (startingMode == GameMode.Shootout)
            {
                BallistixBall ball = other.gameObject.GetComponent<BallistixBall>();
                scoreManager.Shootout(ball.BallPlayerNumber, goalTrackerIndex);
            }
            
          
        }
    }

    public void EnableBlocker()
    {
        Debug.Log(goalBlocker);
        goalBlocker.SetActive(true);
    }
        
     
}
