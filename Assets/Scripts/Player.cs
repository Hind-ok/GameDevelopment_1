using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D rb;
    public float speed;
    public float jumpingPower;
    public LayerMask groundLayer;
    public Transform groundCheck;
    //< definir script pour l animation  
    Animator animator;
    //> definir script pour l animation
    //climb 
    // Rigidbody2D rb2;
     bool canClimb=false;
     float vertical;
    //
    //debut :controle de sprite vers la gauche ou direction origine
    float horizontal;
    SpriteRenderer sr;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    //fin :controle de sprite vers la gauche ou direction origine

        private void FixedUpdate()
        {
            rb.linearVelocity = new Vector2(horizontal * speed, canClimb ? vertical * speed : rb.velocity.y);
            //debut update :Animation du personnage
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            animator.SetBool("IsGrounded", IsGrounded());
            //fin update :Animation du personnage
        }

// 0 references
        public void Move(InputAction.CallbackContext context)
        {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y; 
        //debut update :controle de sprite vers la gauche ou direction origine
        sr.flipX = horizontal < 0 ?  true : false; 
        //fin update :controle de sprite vers la gauche ou direction origine

        }
        
        bool IsGrounded()
        {
             return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(.25f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        }

         public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }
    }
    //climb
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Climb"))
        {
            canClimb = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Climb"))
        {
            canClimb = false;
        }
    }

        


    // Update is called once per frame
    void Update()
    {
        
    }
}
