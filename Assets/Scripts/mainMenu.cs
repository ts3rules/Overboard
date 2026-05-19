using UnityEngine;

public class mainMenu : MonoBehaviour
  
 
{
    public GameObject optionsMenu;
    public GameObject mainMenuUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Knockout Game");
    }

    public void options()
    {
        mainMenuUI.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void MainMenu()
    {
        mainMenuUI.SetActive(true);
        optionsMenu.SetActive(false);
    }


}

