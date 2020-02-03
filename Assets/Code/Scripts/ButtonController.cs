using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("MiniGame");
    }

    public void LoadCredit()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadCutScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
