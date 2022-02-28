using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUi;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//daca se apasa ESC pune pauza/reincepe jocul
        {
            if (GameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        pauseMenuUi.SetActive(false);//dezactiveaza UI-ul de pauza
        Time.timeScale = 1f;//reporneste timpul
        GameIsPaused = false;
    }

    void pause()
    {
        pauseMenuUi.SetActive(true);//activeaza UI-ul de pauza
        Time.timeScale = 0f;//opreste timpul
        GameIsPaused = true;
    }
    public void menu()//butoul "menu" reincarca "scena" meniului
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
