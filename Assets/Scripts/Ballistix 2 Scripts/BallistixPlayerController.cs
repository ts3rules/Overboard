using UnityEngine;
using UnityEngine.InputSystem;

public class BallistixPlayerController : MonoBehaviour
{
    public GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputValue value)
    {

        BallistixMovementController movementController = GetComponent<BallistixMovementController>();
        movementController.SetMovement(value.Get<Vector2>());
    }

}
