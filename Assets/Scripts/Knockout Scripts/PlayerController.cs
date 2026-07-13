using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody rb;
    private Vector2 movement;
    public bool onFloor = true;
    public float speed = 5f; 
    public bool hasPowerUp = false;
    private int powerUpDuration = 5;
    private float powerUpStrength = 15f;
    private float normalStrength = 5f;
    public Color PowerUpcolor = Color.red;
    public Renderer rend;
    private float powerUpFlicker = 2f;
    public bool isDead = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputValue value)
    {
        PlayerSetup setup = GetComponent<PlayerSetup>();

        if (!GameSettings.playerOrAI[setup.playerIndex])
        {
            return;
        }
        SetMovement(value.Get<Vector2>());
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = move.normalized;
        rb.AddForce(move * speed);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            rend.material.EnableKeyword("_EMISSION");
            rend.material.SetColor("_EmissionColor", Color.yellow * 2f);
            hasPowerUp = true;
            Invoke("ResetPowerUp", powerUpDuration);
            if(powerUpDuration < powerUpFlicker)
            {

            }
        }

        if (collision.gameObject.tag == "Player" && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
        else if (collision.gameObject.tag == "Player" && !hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
        }
    }

    private void ResetPowerUp()
    {
        rend.material.DisableKeyword("_EMISSION");
        hasPowerUp = false;
    }

    public void SetMovement(Vector2 direction)
    {
        movement = direction;
        Debug.Log(movement);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = false;
        }

    }


}
