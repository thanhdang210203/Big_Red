using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class pickUp : MonoBehaviour
{
    [SerializeField] private int healthValue = 20;
    [SerializeField] private int attackAdd = 2;
    public bool noDmg = false;
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.tag == "Heart")
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<Health_Sys>().TakePortion(healthValue);
                Destroy(gameObject);
                Debug.Log("Gain health");
            }
        }
        else if (this.gameObject.tag == "Attack")
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<Player_Attack>().GainDamage(attackAdd);
                Destroy(gameObject);
                Debug.Log("AttackGained");
            }
        }
        else if (this.gameObject.tag == "DeadZone")
        {
            if (collision.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("Reload Scene");
            }
        }
        else if(this.gameObject.tag == "Goal")
        {
            if (collision.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Debug.Log("Next Level");
            }
        }
        else if (this.gameObject.tag == "Clock")
        {
            if (collision.tag == "Player")
            {
                Time.timeScale = 0.5f;
                StartCoroutine(TimeSlow());
                
                
            }
        }
        else if (this.gameObject.tag == "Shield")
        {
            if (collision.tag == "Player")
            {
                noDmg = true;
                collision.GetComponent<Health_Sys>().Invicibility(noDmg);
                gameObject.SetActive(false);
                Debug.Log("No damage");
            }
        }
    }

    IEnumerator TimeSlow()
    {
        
        Debug.Log("time slowed down");
        Destroy(gameObject);
        yield return new WaitForSeconds(5.0f);
        Debug.Log("time normal");
        Time.timeScale = 1.0f;
    }
}