using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    // variables para coger el movimiento del player
    public float horizontalMove;
    public float verticalMove;

    // para pasar las posiciones del player
    private Vector3 playerInput;

    // para hacer que nuestro player se mueva
    public CharacterController player;

    // para poder controlar la velocidad del player
    public float playerSpeed;
    private Vector3 movePlayer;
    public float gravity = 9.8f;
    public float fallVelocity;
    public float jumpForce;


    // camara
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    //salto

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        movePlayer = movePlayer * playerSpeed;

        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();

        PlayerSkills();

        player.Move(movePlayer * Time.deltaTime);

        Debug.Log(player.velocity.magnitude);
    }

    void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
        }
    }

    //función para determinar la dirección a la que mira la camara
    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    //función para gravedad
    void SetGravity()
    {

        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
    }
}
