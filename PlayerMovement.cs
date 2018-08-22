using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public float speed = 6f;          //Velocidade do player
    public float jumpForce;
    public Animator Anim;
    private Vector2 movement;                 //Vetor do movimento
    private float angle;
    private int onGround;
    private bool aPressed;
    private bool dPressed;
    private bool start;

    void Awake()
    {
        Anim = GetComponent<Animator>();
        angle = 2;
        start = true;
    }

    void Update()
    {
        /* Movimentação X,Y */
        movement = transform.position;
        movement.x += speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        transform.position = movement;

        /* Pulo */
        if (Input.GetAxisRaw("Jump") == 1 && onGround == 1)
        {
            Anim.SetBool("isRunning", false);
            GetComponent<Rigidbody>().AddForce(transform.up * jumpForce);
            onGround = 0;
            Anim.SetBool("isJumping", true);
        }
        /* Mudando a orientação do personagem */
        if (Input.GetKeyDown("d"))
        {
            Anim.SetBool("isRunning", true);
            dPressed = true;
            start = false;

            if (angle != 1 && angle !=2)
            {
                transform.Rotate(Vector3.up, 180f);
                angle = 1;
            }
        }
        else if(Input.GetKeyUp("d"))
            dPressed = false;
        
        if(Input.GetKeyUp("d") && aPressed == false)
            Anim.SetBool("isRunning", false);

        if (Input.GetKeyDown("a"))
        {
            Anim.SetBool("isRunning", true);
            aPressed = true;
            start = false;
            if (angle != 0)
            {
                transform.Rotate(Vector3.up, 180f);
                angle = 0;
            }
        }
        else if (Input.GetKeyUp("a"))
            aPressed = false;

        if (Input.GetKeyUp("a") && dPressed == false)
            Anim.SetBool("isRunning", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("MapLimit"))
            transform.position = new Vector3(0, 0, 0);

        if (collision.gameObject.tag == ("Ground"))
        {
            onGround = 1;
            Anim.SetBool("isJumping", false);           //Apos chegar no chão, seta a animação do pulo para false. e se
                                                        //algum botao esta ainda                
            if (Input.GetKey("d") || Input.GetKey("a"))
                Anim.SetBool("isRunning", true);
        }
    }
}

