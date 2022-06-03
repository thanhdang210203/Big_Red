using UnityEngine;

public class Health_Sys : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool Player_Dead;
    public Health_Bar healthBar;
    private Animator Character_Ani;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
        }

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
}