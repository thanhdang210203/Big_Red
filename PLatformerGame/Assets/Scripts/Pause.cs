using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenu;
    public GameObject WinMenu;
    public GameObject FailMenu;
    public AudioSource audio;
    public static bool GameWon = false;

    private void Start()
    {
        GamePaused = false;
        GameWon = false;
        pauseMenu.SetActive(false);
        WinMenu.SetActive(false);
        FailMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                StopGame();
            }
        }
    }

    private void Resume()
    {
        pauseMenu.SetActive(false);
        audio.Play(0);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    private void StopGame()
    {
        pauseMenu.SetActive(true);
        audio.Pause();   
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading menu...");
        SceneManager.LoadScene("Menu");
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        audio.Play(0);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game....");
    }

    public void RestartGame()
    {
        pauseMenu.SetActive(false);
        Debug.Log("Game restrating...");
        GamePaused = false;
        Time.timeScale = 1f;
        StartCoroutine(Reload());
    }

    public void NextLevel()
    {
        Debug.Log("Next Level loading...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(1);
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}