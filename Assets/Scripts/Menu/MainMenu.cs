using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Load the game
    public void StartGame()
    {
        SceneManager.LoadScene("LoadingScreen");
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }

}
