using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
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

    [Header("Events")]
    [Space]
    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool>
    { }

    private void Awake()
    {
        Player = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    // Start is called before the first frame update
    private void Start()
    {
        //gets the Animator component from the player and stores it in the variable Character_anim
        Character_anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
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

    private void Update()
    {
        GroundCheck();
        Movement();
        Jump();
    }

    private void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;

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

          

            if (facingRight == true)
            {
                Flip();
            }
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Player.velocity = Vector2.up * Jump_force;
            Character_anim.SetTrigger("IsJumping");
            Debug.Log("Jumppppp");
        }
    }
}