using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    public Joystick joystick;

    [SerializeField]
    public float joystickSensitivity;

    [SerializeField]
    public float horizontalSpeed;

    [SerializeField]
    public float jumpForce;

    [SerializeField]
    public float maxVelX;

    public Rigidbody2D rb;

    [SerializeField]
    public SpriteRenderer spriteRenderer;

    [SerializeField]
    public Animator animCont;

    private bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animCont = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();   
    }
    private void _Move()
    {
        if (joystick.Horizontal > joystickSensitivity)
        {
            // move to right
            rb.AddForce(Vector2.right * horizontalSpeed * Time.deltaTime);
            spriteRenderer.flipX = false;
            animCont.SetInteger("AnimState", 1);

        }
        else if (joystick.Horizontal < -joystickSensitivity)
        {
            // move to left
            rb.AddForce(Vector2.left * horizontalSpeed * Time.deltaTime);
            spriteRenderer.flipX = true;
            animCont.SetInteger("AnimState", 1);
        }
        else if (joystick.Vertical > joystickSensitivity && grounded)
        {
            // jump
            rb.AddForce(Vector2.up * jumpForce * Time.deltaTime);
        }
        else
        {
            animCont.SetInteger("AnimState", 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}
