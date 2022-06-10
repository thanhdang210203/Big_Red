using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenu;
    private Score ScoreManager;
    public GameObject health;
    public GameObject score_text;
    public GameObject PauseImage;
    public GameObject ContinueImage;

    private void Start()
    {
        GamePaused = false;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        PauseImage.SetActive(true);
        ContinueImage.SetActive(false);
        ScoreManager = FindObjectOfType<Score>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
                Cursor.visible = true;
            }
            else
            {
                StopGame();
                Cursor.visible = false;
            }
        }
    }

    private void Resume()
    {
        pauseMenu.SetActive(false);
        health.SetActive(true);
        score_text.SetActive(true);
        Time.timeScale = 1f;
        GamePaused = false;
        PauseImage.SetActive(true);
        ContinueImage.SetActive(false);
        
    }

    private void StopGame()
    {
        pauseMenu.SetActive(true);
        health.SetActive(false);
        score_text.SetActive(false);
        Time.timeScale = 0f;
        GamePaused = true;
        PauseImage.SetActive(false);
        ContinueImage.SetActive(true);
        
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
        ScoreManager.ScoreNum = 0;
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(0.2f);
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ScoreManager.ScoreNum = 0;
    }
}