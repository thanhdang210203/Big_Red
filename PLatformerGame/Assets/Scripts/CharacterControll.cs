using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    //declare values
    public float walking_speed = 0.002f;

    public float running_speed = 0.005f;
    private bool facingRight = true;
    public float Jump_force;
    public Rigidbody2D Player;
    private GameObject Groundmask;
    public bool isGrounded = false;
    [SerializeField] private Transform groundCheckCollider;
    private const float groundCheckRadious = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Animator Character_anim;
    private bool Falling_Down = false;

    // Start is called before the first frame update
    private void Start()
    {
        //gets the Animator component from the player and stores it in the variable Character_anim
        Character_anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame

    private void Update()
    {
        GroundCheck();
        Movement();
        Jump();
        Attack();
    }

    private void GroundCheck()
    {
        isGrounded = false;

        //Check if the Groundcheck Object is colliding with other
        //2D Colliders that are in the "Ground" Layer
        //if yes (isGrounded = true) else (isGrounded = false)

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadious, groundLayer);
        if (colliders.Length > 0 && colliders.Length < 1.1f)
        {
            isGrounded = true;
            Debug.Log("is grounded");
        }
        else if (colliders.Length > 1.5f)
        {
            Falling_Down = true;
            Character_anim.SetTrigger("isFalling");
        }
        else if (colliders.Length > 1.1f && colliders.Length < 1.3f)
        {
            Falling_Down = true;
            Character_anim.SetTrigger("isLanding");
        }
    }

    private void Movement()
    {
        //Stores the player's position as Vector2 variable
        Vector2 playerPos = this.transform.position;

        //running left and right
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) == false)
        {
            //Debug.Log("running right");
            playerPos.x = playerPos.x + running_speed; //move playerPos a small amount to the right
            this.transform.position = playerPos; //update the player's position to the new value

            Character_anim.SetTrigger("isRunning");
            Debug.Log("Running animation");

            if (facingRight == false)
            {
                Flip();
            }
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) == false)
        {
            //Debug.Log("running left");
            playerPos.x = playerPos.x - running_speed;
            this.transform.position = playerPos;

            Character_anim.SetTrigger("isRunning");

            if (facingRight == true)
            {
                Flip();
            }
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) == true)
        {
            //Debug.Log("walking left");
            playerPos.x = playerPos.x - walking_speed;
            this.transform.position = playerPos;

            Character_anim.SetTrigger("isWalking");

            if (facingRight == true)
            {
                Flip();
            }
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) == true)
        {
            //Debug.Log("walking right");
            playerPos.x = playerPos.x + walking_speed;
            this.transform.position = playerPos;

            Character_anim.SetTrigger("isWalking"); //set the trigger in the animation controller

            if (facingRight == false)
            {
                Flip();
            }
        }

        else
        {
            Character_anim.SetTrigger("Idle");
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Player.velocity = Vector2.up * Jump_force;
            Character_anim.SetTrigger("isJumping");
            Debug.Log("Jumppppp");
        }
        //else
        //{
        //    Character_anim.SetTrigger("Idle");
        //}
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Character_anim.SetTrigger("Slice");
            Debug.Log("Slicing");
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Character_anim.SetTrigger("Bow");
            Debug.Log("Slg");
        }
        else
        {
            Character_anim.SetTrigger("Idle");
        }
    }

    private void Flip()
    {
        Debug.Log("Flipppppp");

        //set the facingRight variable to the opposite of what it was
        facingRight = !facingRight;

        //store the scale of the player in a variable
        Vector2 playerScale = this.transform.localScale;

        //reverse the direction of the player
        playerScale.x = playerScale.x * -1;

        //set the player's scale to the new value
        this.transform.localScale = playerScale;
    }
}