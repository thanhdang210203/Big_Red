using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    //declare values
    #region Public
    public AudioClip Dashing_Sound;
    public float running_speed = 0.005f;
    public float dash_speed;
    public float dashTime;
    public float Jump_force;
    public Rigidbody2D Player;   
    public bool CanDash;
    #endregion
    #region Private
    private bool facingRight = true;
    private GameObject Groundmask;
    [SerializeField] private Transform groundCheckCollider;
    private const float groundCheckRadious = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    private Animator Character_anim;
    private bool Falling_Down = false;
    private bool isJumping = false;
    private Vector2 playerPos;
    [SerializeField] private bool isGrounded = false;
    #endregion

    #region Bool Events
    [Header("Events")]
    [Space]
    public UnityEvent OnLandEvent;
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool>
    { }
    #endregion
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
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
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
        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("running right");
            playerPos.x = playerPos.x + running_speed; //move playerPos a small amount to the right
            this.transform.position = playerPos; //update the player's position to the new value

            if (facingRight == false)
            {
                Flip();
            }
        }
        else if (Input.GetKey(KeyCode.A))
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

    //public void Dash()
    //{
    //    if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) && CanDash == true)
    //    {
    //        //playerPos.x = playerPos.x + dash_speed; //move playerPos a small amount to the right
    //        //this.transform.position = playerPos; //update the player's position to the new value
    //        //Player.velocity = Vector2.right * Jump_force;
    //        Debug.Log("Is Dashinggggg");
    //        if (facingRight == false)
    //        {
    //            Flip();
    //        }
    //        StartCoroutine(Latecall_Dash());
    //    }
    //    else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) && CanDash == true)
    //    {
    //        //playerPos.x = playerPos.x - dash_speed;
            
    //        //Player.velocity = Vector2.up * Jump_force;
    //        Debug.Log("Is Dashinggggg");
    //        if (facingRight == true)
    //        {
    //            Flip();
    //        }
    //        StartCoroutine(Latecall_Dash());
    //    }
    //}

    private IEnumerator Latecall_Dash()
    {
        CanDash = false;
        yield return new WaitForSeconds(dashTime);
        CanDash = true;
    }
}