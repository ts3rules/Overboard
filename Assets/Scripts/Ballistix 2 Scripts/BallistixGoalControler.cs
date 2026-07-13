using UnityEngine;

public class BallistixGoalControler : MonoBehaviour
{
    private int player1score;
    private int player2score;
    private int player3score;
    private int player4score;
    private int lives = 10;
    public GameObject[] goalBlockers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] goaltraker; 
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(player1score >= lives)
        {

            //BallistixBlockers blocker = GetComponent<BallistixBlockers>();
            goalBlockers[0].SetActive(true);
            
        }
        if (player2score >= lives)
        {

            //BallistixBlockers blocker = GetComponent<BallistixBlockers>();
            goalBlockers[1].SetActive(true);

        }
        if (player3score >= lives)
        {

            //BallistixBlockers blocker = GetComponent<BallistixBlockers>();
            goalBlockers[2].SetActive(true);

        }
        if (player4score >= lives)
        {

            //BallistixBlockers blocker = GetComponent<BallistixBlockers>();
            goalBlockers[3].SetActive(true);
           

        }
    }

    public void GoalScore(GameObject goal)
    {
        Debug.Log("Goal Scored!" + goal.name);
        if(goal.name == "Purple Goal Tracker")
        {
            player1score++;
            Debug.Log($"player1score = {player1score}");
            
        }

        if (goal.name == "Blue Goal Tracker")
        {
            player2score++;
            Debug.Log($"player2score = {player2score}");

        }

        if (goal.name == "Green Goal Tracker")
        {
            player3score++;
            Debug.Log($"player3score = {player3score}");

        }

        if (goal.name == "Red Goal Tracker")
        {
            player4score++;
            Debug.Log($"player4score = {player4score}");

        }

    }

}
