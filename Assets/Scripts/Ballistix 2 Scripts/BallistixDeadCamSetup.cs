using UnityEngine;

public class BallistixDeadCamSetup : MonoBehaviour
{
    [SerializeField] private Camera[] deadCams;

    private void Awake()
    {
        foreach (Camera cam in deadCams)
        {
            cam.enabled = false;
        }
    }

    private void Start()
    {
        SetupCameras();
    }

    private void SetupCameras()
    {
        deadCams[0].rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
        deadCams[1].rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        deadCams[2].rect = new Rect(0f, 0f, 0.5f, 0.5f);
        deadCams[3].rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
    }

    public void EnableDeadCam(int playerIndex)
    {
        deadCams[playerIndex].enabled = true;
    }
}