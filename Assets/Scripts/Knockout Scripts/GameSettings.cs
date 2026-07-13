using UnityEngine;
using UnityEngine.Rendering;

public class GameSettings : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    static public bool[] playerOrAI = new bool[4] { false, false, false, false };
    void Start()
    {
        
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("Knockout Game");
    }

    public void Twoplayer()
    {
        playerOrAI[0] = true;
        playerOrAI[1] = true;
        playerOrAI[2] = false;
        playerOrAI[3] = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Knockout Game");
    }   

    public void Threeplayer()
    {
        playerOrAI[0] = true;
        playerOrAI[1] = true;
        playerOrAI[2] = true;
        playerOrAI[3] = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Knockout Game");
    }   

    public void Fourplayer()
    {
        playerOrAI[0] = true;
        playerOrAI[1] = true;
        playerOrAI[2] = true;
        playerOrAI[3] = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Knockout Game");
    }   
}
