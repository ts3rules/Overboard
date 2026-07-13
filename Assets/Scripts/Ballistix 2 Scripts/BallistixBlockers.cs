using UnityEngine;

public class BallistixBlockers : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject blocker;
    public GameObject Player;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      public void  PlayerDied ()
    {
        Destroy(Player);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
           
            // Handle collision with the ball
            Rigidbody ballrb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            ballrb.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
        }

    }
}
