using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()//functiile sunt conectate la butoane in Unity
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//trece la "scena" urmatoare, adica jocul propriu-zis
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();//inchide aplicatia
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);//trece la scena tutorial
    }
}
