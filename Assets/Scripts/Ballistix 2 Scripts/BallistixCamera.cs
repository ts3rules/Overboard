using UnityEngine;

public class BallistixCamera : MonoBehaviour
{
    [SerializeField] private BallistixPlayerSetup playerSetup;
    public GameObject Player;
    private Vector3 offsetPlayer1 = new Vector3(0, 0.5f, 1.5f);
    private Vector3 offsetPlayer2 = new Vector3(0, 0.5f, -1.5f);
    private Vector3 offsetPlayer3 = new Vector3(1.5f, 0.5f, 0f);
    private Vector3 offsetPlayer4 = new Vector3(-1.5f, 0.5f, 0f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }
    // Update is called once per frame
    void Update()
    {
        if (playerSetup.playerIndex == 0)
        {
            transform.position = Player.transform.position + offsetPlayer1;
        }

        if (playerSetup.playerIndex == 1)
        {
            transform.position = Player.transform.position + offsetPlayer2;
        }

        if (playerSetup.playerIndex == 2)
        {
            transform.position = Player.transform.position + offsetPlayer3;
        }

        if (playerSetup.playerIndex == 3)
        {
            transform.position = Player.transform.position + offsetPlayer4;
        }

    }
}
