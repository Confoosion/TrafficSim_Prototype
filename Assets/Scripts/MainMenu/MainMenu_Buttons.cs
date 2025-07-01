using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Buttons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Customization()
    {
        SceneManager.LoadScene("Customization");
    }

    public void QuitGame()
    {
        Debug.Log("Game has quit");
        Application.Quit();
    }
}
