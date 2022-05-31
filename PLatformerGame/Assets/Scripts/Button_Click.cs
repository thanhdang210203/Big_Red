using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Click : MonoBehaviour
{
    public AudioClip opener;

    private void Start()
    {
        AudioSource.PlayClipAtPoint(opener, new Vector3(0, 0, 0));
    }

    // Start is called before the first frame update
    public void selectStart()
    {
        Debug.Log("Loading Level");
        SceneManager.LoadScene("1");
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
        SceneManager.LoadScene("1");
        DontDestroyOnLoad(opener);
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