using UnityEngine;

public class BallistixPlayerSetup : MonoBehaviour
{
    public int playerIndex;

    private Camera playerCamera;

    private void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        SetupCamera();
    }

    private void SetupCamera()

    {
        Debug.Log($"{gameObject.name} index: {playerIndex}");
        switch (playerIndex)
        {
            case 0:
                playerCamera.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
                break;

            case 1:
                playerCamera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                break;

            case 2:
                playerCamera.rect = new Rect(0f, 0f, 0.5f, 0.5f);
                break;

            case 3:
                playerCamera.rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
                break;
        }
    }
}

