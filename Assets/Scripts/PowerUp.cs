using UnityEngine;
using UnityEngine.UIElements;

public class PowerUp : MonoBehaviour
{
    Vector3 spin = new Vector3(10, 0, 0);
    int speed = 10;
    int spawnInterval = 5;
    int spawnTotal = 2;
    int spawnTime = 5;
    private float spawnPositionZUpper = 6.5f;
    private float spawnPositionZLower = -11.3f;
    private float spawnPositionXUpper = 10.4f;
    private float spawnPositionXLower = -10;
    public GameObject powerUpPrefab;
    private int spawnCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Invoke("SpawnPowerUp", spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        //spin the power up
        transform.Rotate(spin * Time.deltaTime);

    }

}
