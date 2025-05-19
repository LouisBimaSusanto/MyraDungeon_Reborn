using System;
using UnityEngine;

public class PlayeMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public float Acceleration;
    public float MovementSpeed;
    public float JumpSpeed;

    [Range(0f, 1f)]
    public float groundDecay;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;
    public bool isGround;

    float xInput;
    float yInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        HandleJump();
    }

    private void FixedUpdate()
    {
        CheckGround();
        ApplyFriction();
        moveWithInput();
    }

    void moveWithInput()
    {
        if (MathF.Abs(xInput) > 0)
        {
            float increment = xInput * Acceleration;
            float newSpeed = Mathf.Clamp(body.linearVelocity.x + increment, -MovementSpeed, MovementSpeed);

            body.linearVelocity = new Vector2(newSpeed, body.linearVelocity.y);

            FaceInput();
        }


    }

    void FaceInput()
    {
        float direction = MathF.Sign(xInput); // Sign for current value either negative or positive
        transform.localScale = new Vector3(direction, 1, 1);
    }

    void HandleJump()
    {

        if (Input.GetButtonDown("Jump") && isGround)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, JumpSpeed);
        }
    }

    void GetInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }

    void CheckGround()
    {
        isGround = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }

    void ApplyFriction()
    {
        if (isGround && xInput == 0)
        {
            Vector2 velocity = body.linearVelocity;
            velocity.x *= groundDecay;
            body.linearVelocity = velocity;
        }
    }
}
