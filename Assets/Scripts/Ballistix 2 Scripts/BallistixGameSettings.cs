using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class BallistixGameSettings : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    static public bool[] playerOrAI = new bool[4] { false, false, false, false };

    //default lifes for the players
    public static int startingLives = 10;
    //default starting game mode 
    public static GameMode startingMode = GameMode.Classic;

    //lives values
    [SerializeField] private TextMeshProUGUI livesValue;

    [SerializeField] private TextMeshProUGUI gameModeValue;

    [SerializeField] private  GameObject classicSettingsPanel;

    [SerializeField] private GameObject shootoutSettingsPanel;



    public enum GameMode
    {
        Classic,
        Shootout
    }



    void Start()
    {
        livesValue.text = startingLives.ToString();
        gameModeValue.text = startingMode.ToString();

    }

    public void IncreaseLives()
    {
        startingLives = Mathf.Clamp(startingLives + 1, 1, 99);
        livesValue.text = startingLives.ToString();
    }

    public void DecreaseLives()
    {
        startingLives = Mathf.Clamp(startingLives - 1, 1, 99);
        livesValue.text = startingLives.ToString();
    }

    public void ChangeGameMode()
    {
        Debug.Log("ChangeGameMode called");
        if (startingMode == GameMode.Classic)
        {
            startingMode = GameMode.Shootout;
        }
        else
        {
            startingMode = GameMode.Classic;
        }

        gameModeValue.text = startingMode.ToString();

        UpdateSettingsUI();
    }

    private void UpdateSettingsUI()
    {
        if (startingMode == GameMode.Classic)
        {
            classicSettingsPanel.SetActive(true);
            shootoutSettingsPanel.SetActive(false);
        }
        else
        {
            classicSettingsPanel.SetActive(false);
            shootoutSettingsPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Oneplayer()
    {
        playerOrAI[0] = true;
        playerOrAI[1] = false;
        playerOrAI[2] = false;
        playerOrAI[3] = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Ballistix 2");
    }

    public void Twoplayer()
    {
        playerOrAI[0] = true;
        playerOrAI[1] = true;
        playerOrAI[2] = false;
        playerOrAI[3] = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Ballistix 2");
    }   

    public void Threeplayer()
    {
        playerOrAI[0] = true;
        playerOrAI[1] = true;
        playerOrAI[2] = true;
        playerOrAI[3] = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Ballistix 2");
    }   

    public void Fourplayer()
    {
        playerOrAI[0] = true;
        playerOrAI[1] = true;
        playerOrAI[2] = true;
        playerOrAI[3] = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Ballistix 2");
    }   


}
