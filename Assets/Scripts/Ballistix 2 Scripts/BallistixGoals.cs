using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject goal; // Reference to the goal object
    public BallistixGoalControler goalController;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
                
            Debug.Log("Goal Scored!");
            goalController.GoalScore(goal); // Call the GoalScore method in the goal controller
            // You can add additional logic here, such as updating the score or resetting the ball's position. 
        }
    }
}
