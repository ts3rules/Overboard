using UnityEngine;

public class BallistixPlayerSetup : MonoBehaviour
{
    public int playerIndex;
    [SerializeField] private BallistixDeadCamSetup deadCamSetup;

    public GameObject player;


    [SerializeField] private Camera playerCamera;
    

    private void Awake()
    {
        
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

    public void PlayerOut()
    {
        Debug.Log("Player Out");
        playerCamera.enabled = false;
        Debug.Log(playerIndex);
        deadCamSetup.EnableDeadCam(playerIndex);
        GetComponent<BalllistixPaddles>().enabled = false;
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;
        Collider col = GetComponent<Collider>();
        col.enabled = false;


    }
}

