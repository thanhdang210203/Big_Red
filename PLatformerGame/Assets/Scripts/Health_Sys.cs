using UnityEngine;

public class Health_Sys : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool Player_Dead;
    public Health_Bar healthBar;
    private Animator Character_Ani;
    public int healthPickUp = 20;
    public GameObject heart;
    public LayerMask enemies_attack;

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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Character_Ani.SetTrigger("isHurt");
        healthBar.SetHealth(currentHealth);
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
}