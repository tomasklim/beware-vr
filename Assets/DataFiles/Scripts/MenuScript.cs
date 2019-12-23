using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1Scene");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2Scene");
    }

    public void OpenTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void ShowMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
