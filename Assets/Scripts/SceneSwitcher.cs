using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    private int MainScene = 1;
    private int MenuScene = 0;
    public void MoveToMain()
    {
        SceneManager.LoadScene(MainScene);
    }

    public void MoveToMenu()
    {
        SceneManager.LoadScene(MenuScene);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
