using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{

    private float horizontalMove = 0f;
    private float verticalMove = 0f;

    static public int tipoJoystick = 3;
    public Joystick joystickFijo;
    public Joystick joystickDinamico;
    public Joystick joystickSeguimiento;
    public GameObject joystickFijo_;
    public GameObject joystickDinamico_;
    public GameObject joystickSeguimiento_;


    public float runSpeedHorizontal = 1;
    public float runSpeed = 1.25f;
    public float jumpSpeed = 3;
    public float doubleJumpSpeed = 2.5f;
    private bool canDoubleJump;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    private Rigidbody2D rd2D;
    void Start()
    {
        rd2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Double Jump", false);
            animator.SetBool("Falling", false);
        }

        if (rd2D.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else if (rd2D.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }
    }

    void FixedUpdate()
    {
        switch(tipoJoystick)
        {
            case 1:

                joystickDinamico_.SetActive(false);
                joystickSeguimiento_.SetActive(false);
                joystickDinamico.enabled = false;
                joystickSeguimiento.enabled = false;
                joystickFijo.enabled = true;
                joystickFijo_.SetActive(true);
                     horizontalMove = joystickFijo.Horizontal * runSpeedHorizontal;
                        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;
                break;

            case 2:
           
                joystickFijo_.SetActive(false);
                joystickSeguimiento_.SetActive(false);
                joystickDinamico_.SetActive(true);
            horizontalMove = joystickDinamico.Horizontal * runSpeedHorizontal;
            transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;
                break;

                case 3:
                joystickFijo_.SetActive(false);
                joystickDinamico_.SetActive(false);
                joystickSeguimiento_.SetActive(true);
                horizontalMove = joystickSeguimiento.Horizontal * runSpeedHorizontal;
                transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;
                break;
        }
    }

    public void Jump()
    {
        if (CheckGround.isGrounded)
        {
            canDoubleJump = true;
            rd2D.velocity = new Vector2(rd2D.velocity.x, jumpSpeed);
        }
        else
        {
            if (canDoubleJump)
            {
                animator.SetBool("Double Jump", true);
                rd2D.velocity = new Vector2(rd2D.velocity.x, doubleJumpSpeed);
                canDoubleJump = false;
            }
        }
    }

}
