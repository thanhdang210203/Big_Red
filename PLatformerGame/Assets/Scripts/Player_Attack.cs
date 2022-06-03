using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private int currentAttack = 0;
    private float timeSinceAttack = 0.0f;

    // Update is called once per frame
    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Attack();
        //}
        //Attack();
        if (Input.GetMouseButtonDown(0) && timeSinceAttack > 0.25f)
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
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Slice 1");

        Collider2D[] hitEnemise = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemise)
        {
            Debug.Log("We hit " + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}