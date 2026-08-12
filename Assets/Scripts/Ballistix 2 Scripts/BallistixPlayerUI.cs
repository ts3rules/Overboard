using TMPro;
using UnityEngine;
using static BallistixGameSettings;

public class BallistixPlayerUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TextMeshProUGUI gameModeText;
    [SerializeField] private TextMeshProUGUI gameModeValue;
    int playerlifes = startingLives;

    void Start()
    {
        if (startingMode == GameMode.Classic)
        {
            gameModeText.text = "LIFES:";
            gameModeValue.text = playerlifes.ToString();
        }
        if (startingMode == GameMode.Shootout)
        {
            gameModeText.text = "GOALS:";
        }
    }

    public void LoseLife()
    {
        playerlifes--;
        gameModeValue.text = playerlifes.ToString();

    }


    // Update is called once per frame
    void Update()
    {

    }
}
