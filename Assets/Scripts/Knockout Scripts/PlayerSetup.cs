using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public int playerIndex;

    void Start()
    {
        AiController ai = GetComponent<AiController>();
        PlayerController player = GetComponent<PlayerController>();

        if (GameSettings.playerOrAI[playerIndex])
        {
            ai.enabled = false;
        }
        else
        {
            ai.enabled = true;
        }

        Debug.Log(GameSettings.playerOrAI[playerIndex]);
        Debug.Log("Player Index: " + playerIndex);
    }
}