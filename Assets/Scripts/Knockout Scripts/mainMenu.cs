using UnityEngine;

public class mainMenu : MonoBehaviour
  
 
{
    public GameObject optionsMenu;
    public GameObject mainMenuUI;
    public GameObject choosePlayers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Knockout Game");
    }

    public void options()
    {
        choosePlayers.SetActive(false);
        mainMenuUI.SetActive(false);
        optionsMenu.SetActive(true);

    }

    public void MainMenu()
    {
        choosePlayers.SetActive(false);
        optionsMenu.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void PlayerCount()
    {
        optionsMenu.SetActive(false);
        mainMenuUI.SetActive(false);
        choosePlayers.SetActive(true);
    }



    public void QuitGame()
    {
        Application.Quit();
    }   

   


}

