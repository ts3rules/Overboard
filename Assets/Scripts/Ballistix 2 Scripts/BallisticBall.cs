using UnityEngine;

public class BallisticBall : MonoBehaviour
{
    Rigidbody rb;
    private float speed = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
