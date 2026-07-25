using UnityEngine;
using UnityEngine.InputSystem;


public class BallistixPlayerController : MonoBehaviour
{
    public GameObject Player;
    private BallistixPowerShot powerShot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        powerShot = GetComponentInChildren<BallistixPowerShot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPowerShot(InputValue value)
    {
        if (value.isPressed)
        {
            powerShot.Fire();
        }
    }

    public void OnMove(InputValue value)
    {

        BallistixMovementController movementController = GetComponent<BallistixMovementController>();
        movementController.SetMovement(value.Get<Vector2>());
    }

}
