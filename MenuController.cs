using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public string newGame;

    public void startGameButton()
    {
        SceneManager.LoadScene(newGame);
    }

    public void exitButton()
    {
        Application.Quit();
    }
}
