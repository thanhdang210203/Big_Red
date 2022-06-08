using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public GameObject self;
    private Score Scorenum;
    [SerializeField] private int currentHealth;
    [SerializeField] private bool EnemyDied = false;
    public Animator Animate;
    public int Skullman_Point = 100;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void TakeDamage(int damage)
    {
        Animate.SetTrigger("Hurt");
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        EnemyDied = true;
        Debug.Log("Enemy dead");
        Animate.SetBool("isDead", true);
        StartCoroutine(DestroyEnemy());

        if (EnemyDied)
        {
            if (this.gameObject.tag == "Skullman")
            {
                Debug.Log("Skullman died");
                Score.ScoreNum += 100;
            }
        }
    }

    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(1.0f);
        self.SetActive(false);
    }
}