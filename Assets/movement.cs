using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public bool isJumping;
    public bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;







    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;


    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        float horizontalMovement = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            Debug.Log(isJumping);
        }

        MovePlayer(horizontalMovement);

        
    }
    
    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, -0.5);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
            Debug.Log(isJumping);
        }
    }

}
