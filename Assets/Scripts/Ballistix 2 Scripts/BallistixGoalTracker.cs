using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallistixGoalTracker : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BallistixScoreManager scoreManager;
    public GameObject goalTracker;
    public GameObject goalBlocker;
    public int goalTrackerIndex;
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
            scoreManager.GoalScore(goalTrackerIndex);
        }
    }

    public void EnableBlocker()
    {
        Debug.Log(goalBlocker);
        goalBlocker.SetActive(true);
    }
        
     
}
