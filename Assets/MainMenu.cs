using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToUser()
    {
        SceneManager.LoadScene("UserName Screen");
    }

    public void GoToLobby()
    {
        SceneManager.LoadScene("Game Lobby");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
