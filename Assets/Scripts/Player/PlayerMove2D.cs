using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMove2D : MonoBehaviour
{
    public float move_acceleration;
    public float move_maxSpeed;

    public float crouchColliderSize;

    int move_dir;
    [Header("Jump Settings")]
    public float jump_startJumpForce;
    public float jump_jumpForce;
    public float jump_jumpTime;



    [Header("KeyCodes")]
    public KeyCode key_moveLeft = KeyCode.A;
    public KeyCode key_moveRight = KeyCode.D;
    public KeyCode key_jump = KeyCode.W;
    public KeyCode key_crouch = KeyCode.DownArrow;

    [Header("Check Settings")]
    public LayerMask layer_ground;
    public BoxCollider2D check_ground;
    public BoxCollider2D check_left;
    public BoxCollider2D check_right;

    public BoxCollider2D collider_player;


    public bool isPlayerGrounded;
    bool canMoveLeft;
    bool canMoveRight;

    float jump_t;
    bool jump_isJumping;
    public bool move_isMovning;
    public bool crouch_isCrouching;
    Rigidbody2D rig;
    public PlayerSound sound;


    Vector2 acceleration;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        CameraController.playerBody = rig;

        EnemyAi.player = transform;
    }

    void Update()
    {
        MoveCheck();
        SetMoveAxis();

        //Jump something
        if(Input.GetKeyDown(key_jump))
        {
            StartJump();
        }

        if(Input.GetKeyUp(key_jump))
        {
            StopJump();
        }

        //CROUCH
        if(Input.GetKey(key_crouch) && isPlayerGrounded)
        {
            crouch_isCrouching = true;

            collider_player.size = new Vector2(1,0.6f);
            collider_player.offset = new Vector2(0,0.3f);
        }
        if(Input.GetKeyUp(key_crouch))
        {
            crouch_isCrouching = false;

            collider_player.size = new Vector2(1,1.2f);
            collider_player.offset = new Vector2(0,0.6f);
        }

        FlipDir();
        
    }
    void FixedUpdate()
    {
        acceleration = new Vector2();
        Move();

        if(jump_isJumping)
        {
            Jump();
        }

        rig.AddForce(acceleration);
    }
    void Move()
    {
        //Debug.Log(rig.velocity);
        if(rig.velocity.x < move_maxSpeed && rig.velocity.x > -move_maxSpeed)
        {
            acceleration.x = move_dir * move_acceleration * Time.fixedDeltaTime;
        }
    }
    public void SetMoveAxis()
    {
        move_dir = 0;
        move_isMovning = false;

        if(Input.GetKey(key_moveRight) && canMoveRight && !crouch_isCrouching)
        {
            move_dir = 1;
            move_isMovning = true;
        }
        if(Input.GetKey(key_moveLeft) && canMoveLeft && !crouch_isCrouching)
        {
            move_dir = -1;
            move_isMovning = true;
        }



    }

    void MoveCheck()
    {
        //uzemění
        if(Physics2D.OverlapBox((Vector2)transform.position+check_ground.offset,check_ground.size,0,layer_ground))
        {
            isPlayerGrounded = true;

        }
        else isPlayerGrounded = false;

        //doleva
        if(!Physics2D.OverlapBox((Vector2)transform.position+check_left.offset,check_left.size,0,layer_ground))
        {
            canMoveLeft = true;
        }
        else canMoveLeft = false;

        //doprava brm brm
        if(!Physics2D.OverlapBox((Vector2)transform.position+check_right.offset,check_right.size,0,layer_ground))
        {
            canMoveRight = true;
        }
        else canMoveRight = false;

        //Debug.Log("ground: " + isPlayerGrounded +",  left: "+ canMoveLeft + ", right: "+ canMoveRight);
    }
    void StartJump()
    {
        if(isPlayerGrounded)
        {
            jump_t = 0;
            jump_isJumping = true;

            rig.velocity = Vector2.up*jump_startJumpForce;
        }
    }
    void Jump()
    {
        if(jump_t <= jump_jumpTime) 
        {
            jump_t += Time.deltaTime;

            rig.velocity += Vector2.up*jump_jumpForce*Time.deltaTime;
        }
        else StopJump();
    }
    void StopJump()
    {
        jump_isJumping = false;
    }
    public void FlipDir()
    {
        if(move_dir == 1)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if(move_dir == -1)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
    }
    //Hello random reader

}
