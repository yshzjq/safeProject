using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButtonScripts : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
