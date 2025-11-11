using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void OnButtonPress()
    {
        SceneManager.LoadScene("TutorialOne");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
