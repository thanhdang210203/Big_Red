using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public GameObject self;
    [SerializeField] private int currentHealth;
    public Animator Animate;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        Animate.SetTrigger("Hurt");
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();

        }
    }

    void Die()
    {
        Debug.Log("Enemy dead");

        Animate.SetBool("isDead", true);
        StartCoroutine(DestroyEnemy());
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(1.0f);
        self.SetActive(false);
    }
}
