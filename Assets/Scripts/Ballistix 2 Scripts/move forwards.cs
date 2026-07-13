using UnityEngine;

public class moveforwards : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float speed = 50f; // Speed at which the object will move forward
    private Rigidbody rb;
    void Start()
    {
        //needs to move on the z axis, so we add to the position of the object on the z axis
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
