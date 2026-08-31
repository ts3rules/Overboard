using UnityEngine;

public class BallistixBall : MonoBehaviour
{
    Rigidbody rb;
    Renderer BallRender;

   

    // ball number of the player to keep track of who gets a point in shootout mode
    public int BallPlayerNumber = -1;

    string colour;
    private float speed = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BallRender = GetComponent<Renderer>();
      
    //colour = renderer.material.color;
    //GetComponent<Renderer>().material.color;
}

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {

            rb.AddForce(-collision.contacts[0].normal * 10f, ForceMode.Impulse);
            Debug.Log("Ball collied with another ball!");
        }
        //shootout logic for changing the ball colour and gettig the player int value
        if(collision.gameObject.CompareTag("Player"))
        {
            if (BallistixGameSettings.startingMode == BallistixGameSettings.GameMode.Shootout)
            {
                BallistixPlayerSetup player = collision.gameObject.GetComponent<BallistixPlayerSetup>();
                BallPlayerNumber = player.playerIndex;
                Debug.Log("What is this number?" + BallPlayerNumber);
                BallRender.material.color = player.playerColour;

            }
        }
            
    }

    //private void FixedUpdate()
    //{
       // if (rb.linearVelocity.magnitude < 1f)
       // {
          //  Vector3 randomDirection =
               // new Vector3(
                  //  Random.Range(-1f, 1f),
                 //   0,
               //     Random.Range(-1f, 1f));

           // rb.AddForce(randomDirection.normalized * speed);
       // }
   // }
}
