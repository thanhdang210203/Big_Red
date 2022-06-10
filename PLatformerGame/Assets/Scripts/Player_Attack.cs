using System.Collections;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private bool attackGained = false;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackRate = 2.0f;
    private float nextAttackTime = 0.0f;
    public LayerMask enemyLayers;
    private int currentAttack = 0;
    private float timeSinceAttack = 0.0f;
    private bool facingRight = true;
    public bool CanShootBow = false;
    [SerializeField] private int MaxShoot = 5;
    [SerializeField] private int CurrentShot = 0;
    public int attackDamage = 40;

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();

            Debug.Log("Attacking");
        }
        else if (Input.GetMouseButtonDown(1))
        {
            RangeAttack();
        }
    }

    private void Attack()
    {
        currentAttack++;

        // Loop back to one after third attack
        if (currentAttack > 3)
            currentAttack = 1;

        // Reset Attack combo if time since last attack is too large
        if (timeSinceAttack > 1.0f)
            currentAttack = 1;

        // Call one of three attack animations "Attack1", "Attack2", "Attack3"
        animator.SetTrigger("Slice" + currentAttack);

        // Reset timer
        timeSinceAttack = 0.0f;

        Collider2D[] hitEnemise = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemise)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            Debug.Log("We hit " + enemy.name);
        }
    }

    public void GainDamage(int attackAdd)
    {
        attackGained = true;
        attackDamage = attackDamage * attackAdd;
        StartCoroutine(CoolDown());
    }

    public void RangeAttack()
    {
        if (CanShootBow == true)
        {
            animator.SetBool("CanShotBow", true);
            animator.SetTrigger("Bow");
            //add delay later
            StartCoroutine(BowDelay());
            CurrentShot++;
            if (CurrentShot == MaxShoot)
            {
                CurrentShot = MaxShoot;
                animator.SetBool("CanShotBow", false);
                CanShootBow = false;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }

    private IEnumerator BowDelay()
    {
        CanShootBow = false;
        yield return new WaitForSeconds(0.69f);
        CanShootBow = true;
    }

    public IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(3.0f);
        attackGained = false;
        attackDamage = 40;
    }
}