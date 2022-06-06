using UnityEngine;
using System.Collections;
public class Health_Sys : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool Player_Dead;
    public Health_Bar healthBar;
    private Animator Character_Ani;
    public int healthPickUp = 20;
    public GameObject heart;
    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        Player_Dead = false;
    }

    // Update is called once per frame
    private void Update()
    { 
        if (currentHealth == 0)
        {
            Player_Dead = true;
            Character_Ani.SetBool("playerDead", true);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Heart")
        {
            currentHealth += healthPickUp;
            Debug.Log("health boosted");
            heart.SetActive(false);
        }
    }
}