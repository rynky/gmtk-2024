using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xInput;
    private Rigidbody2D rb;
    [SerializeField] public float speed = 5f;
    [SerializeField] public LayerMask whatIsGround;
    [SerializeField] public Transform feet;
    private bool isGrounded = false;
    [SerializeField] public float checkRadius = 0.1f;
    [SerializeField] public float jumpForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isGrounded);

        // Check the horizontal input received (-1, 0, 1)
        xInput = Input.GetAxis("Horizontal");

        // Check if the player is grounded
        if (Physics2D.OverlapCircle(feet.position, checkRadius, whatIsGround))
        {
            isGrounded = true;
        } 
        else
        {
            isGrounded = false;
        }

        // Jump if the space bar or "W" is clicked
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        // Move the player according to the horizontal input
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
    }
}
