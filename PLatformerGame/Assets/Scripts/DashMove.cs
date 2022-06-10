using UnityEngine;

public class DashMove : MonoBehaviour
{
    private Rigidbody2D Player;
    public float dashSpeed;
    private float dashTime;
    public float StartDashTime;
    private int direction;

    // Start is called before the first frame update
    private void Start()
    {
        Player = GetComponent<Rigidbody2D>();
        dashTime = StartDashTime;
    }

    // Update is called once per frame
    private void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
            {
                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
            {
                direction = 2;
            }
            else
            {
                if (dashTime <= 0)
                {
                    direction = 0;
                    dashTime = StartDashTime;
                    Player.velocity = Vector2.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;
                    if (direction == 1)
                    {
                        Player.velocity = Vector2.left * dashSpeed;
                    }
                    else if (direction == 2)
                    {
                        Player.velocity = Vector2.right * dashSpeed;
                    }
                }
            }
        }
    }
}