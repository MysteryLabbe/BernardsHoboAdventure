using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void OnStartGameClicked()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void OnQuitGameClicked()
    {
        Application.Quit();
    }
}
