using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerNewWorld : MonoBehaviour
{
    public CharacterController controlerPlayer;

    public float horizontalMove;
    public float verticalMove;
    public float speed;
    public float gravity;
    public float fallVelocity;

    public Camera camara;

    private Vector3 playerInput;
    private Vector3 camaraForward;
    private Vector3 camRight;
    private Vector3 movePlayer;
    private bool canMovePlayer;

    

    void Start()
    {
        controlerPlayer = GetComponent<CharacterController>();
        this.verticalMove = 0;
        this.horizontalMove = 0;
        this.gravity = 9.8f;
        this.canMovePlayer = true;
    }

    void Update()
    {
        if (this.canMovePlayer)
        {
            this.horizontalMove = Input.GetAxis("Horizontal");
            this.verticalMove = Input.GetAxis("Vertical");

            this.playerInput = new Vector3(this.horizontalMove, 0, this.verticalMove);
            this.playerInput = Vector3.ClampMagnitude(this.playerInput, 1);

            DirectionCamara();

            this.movePlayer = playerInput.x * camRight + playerInput.z * camaraForward;

            //Aqui esto no va
            //this.movePlayer = this.movePlayer * this.speed;

            this.controlerPlayer.transform.LookAt(this.controlerPlayer.transform.position + movePlayer);

            SetGravity();

            this.controlerPlayer.Move(this.movePlayer * speed * Time.deltaTime);
        }

    }

    private void DirectionCamara()
    {
        camaraForward = camara.transform.forward;
        camRight = camara.transform.right;

        camaraForward.y = 0;
        camRight.y = 0;

        camaraForward = camaraForward.normalized;
        camRight = camRight.normalized;
    }

    public void SetGravity()
    {
        if (this.controlerPlayer.isGrounded)
            this.fallVelocity = -gravity * Time.deltaTime;
        else
            this.fallVelocity -= gravity * Time.deltaTime;

        this.movePlayer.y = this.fallVelocity;
    }

    public void setMovementPlayer(bool valor)
    {
        this.canMovePlayer = valor;
    }


}
