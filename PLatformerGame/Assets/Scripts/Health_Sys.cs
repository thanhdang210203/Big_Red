using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Health_Sys : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool Player_Dead;
    public Health_Bar healthBar;
    public Animator Character_Ani;
    public int healthPickUp = 20;
    public GameObject heart;
    private Score ScoreManager;
    [SerializeField] private bool canTakeDamage;
    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        Player_Dead = false;
        canTakeDamage = true;
        ScoreManager = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentHealth == 0)
        {
            Player_Dead = true;
            Character_Ani.SetBool("playerDead", true);
            Resources.UnloadUnusedAssets();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            ScoreManager.ScoreNum = 0;
        }
        if (currentHealth >= 100)
        {
            currentHealth = 100;
        }
    }

    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            currentHealth -= damage;
            Character_Ani.SetTrigger("isHurt");
            healthBar.SetHealth(currentHealth);
        }
        
    }

    public void Invicibility(bool noDmg)
    {
        if (noDmg == true)
        {
            canTakeDamage = false;
            StartCoroutine(Wait());
            canTakeDamage = true;
        }
        
    }

    public void TakePortion(int healthPickup)
    {
        currentHealth += healthPickup;

        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Heart")
        {
            currentHealth += healthPickUp;
            Debug.Log("health boosted");
            heart.SetActive(false);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f);
    }
}