using UnityEngine;

public class BallistixSpeedBoost : MonoBehaviour
{
    public GameObject SpeedBoost;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BallistixMovementController playerMovement = collision.gameObject.GetComponent<BallistixMovementController>();
            if (playerMovement != null)
            {
                playerMovement.ApplySpeedBoost();
                Destroy(SpeedBoost);
            }
        }

    }
}
