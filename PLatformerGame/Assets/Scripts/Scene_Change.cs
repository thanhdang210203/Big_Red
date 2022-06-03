using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change : MonoBehaviour
{
    private void Start()
    {
    }

    // Start is called before the first frame update
    public void selectStart()
    {
        Debug.Log("Loading Level");
        SceneManager.LoadScene("Tutorial");
    }

    public void selectLevel()
    {
        Debug.Log("Level Select");
        SceneManager.LoadScene("Select Level");
    }

    public void selectQuit()
    {
        Debug.Log("Quiting game");
        Application.Quit();
    }

    public void selectLevel1()
    {
        Debug.Log("Loading Level");
        SceneManager.LoadScene("2");
    }

    public void selectLevel2()
    {
        Debug.Log("Loading Level");
        SceneManager.LoadScene("2");
    }

    public void selectMenu()
    {
        Debug.Log("Loading Menu");
        SceneManager.LoadScene("Menu");
    }

    public void selectLevel3()
    {
        Debug.Log("Loading Level");
        SceneManager.LoadScene("3");
    }

    public void selectLevel4()
    {
        Debug.Log("Loading Level");
        SceneManager.LoadScene("4");
    }

    public void selectLevelSecret()
    {
        Debug.Log("Loading Level");
        SceneManager.LoadScene("Secret Level");
    }
}