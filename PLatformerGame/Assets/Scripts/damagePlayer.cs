using UnityEngine;

public class damagePlayer : MonoBehaviour
{
    public int attackDamage = 2;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<Health_Sys>().TakeDamage(attackDamage);
            Debug.Log("We hit " + player.name);
        }
    }
}