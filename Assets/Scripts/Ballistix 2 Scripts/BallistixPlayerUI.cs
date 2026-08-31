using TMPro;
using UnityEngine;
using static BallistixGameSettings;

public class BallistixPlayerUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TextMeshProUGUI gameModeText;
    [SerializeField] private TextMeshProUGUI gameModeValue;

    [SerializeField] private TextMeshProUGUI round;
    [SerializeField] private TextMeshProUGUI target;
    int playerlifes = startingLives;

    int targetGoals = goalTarget;

    int goals = 0;



    void Start()
    {
        if (startingMode == GameMode.Classic)
        {
            gameModeText.text = "LIFES:";
            gameModeValue.text = playerlifes.ToString();
            round.text = "";
            target.text = "";

        }
        if (startingMode == GameMode.Shootout)
        {
            gameModeText.text = "GOALS:";
            gameModeValue.text = "0";
            target.text = targetGoals.ToString();


        }
    }

    public void LoseLife()
    {
        playerlifes--;
        gameModeValue.text = playerlifes.ToString();

    }

    public void LosePoint()
    {
        if (goals > 0)
        {
            goals--;
            gameModeValue.text = goals.ToString();
        }
    }

    public void ScorePoint()
    {
        goals++;
        gameModeValue.text = goals.ToString();
    }
     


    // Update is called once per frame
    void Update()
    {

    }
}
