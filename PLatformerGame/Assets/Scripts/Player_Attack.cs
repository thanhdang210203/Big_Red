using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private int m_currentAttack = 0;
    private float m_timeSinceAttack = 0.0f;


    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Attack();
        //}
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Attack();
            if (Input.GetMouseButtonDown(0) && m_timeSinceAttack > 0.25f)
            {
                m_currentAttack++;

                // Loop back to one after third attack
                if (m_currentAttack > 3)
                    m_currentAttack = 1;

                // Reset Attack combo if time since last attack is too large
                if (m_timeSinceAttack > 1.0f)
                    m_currentAttack = 1;

                // Call one of three attack animations "Attack1", "Attack2", "Attack3"
                animator.SetTrigger("Slice" + m_currentAttack);

                // Reset timer
                m_timeSinceAttack = 0.0f;
            }
        }
    }

    //void Attack()
    //{
    //    animator.SetTrigger("Slice 1");

    //    Collider2D[] hitEnemise = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

    //    foreach(Collider2D enemy in hitEnemise)
    //    {
    //        Debug.Log("We hit " + enemy.name);
    //    }
    //}

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
