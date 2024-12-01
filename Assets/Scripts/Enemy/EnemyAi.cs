using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public static Transform player; //specifikuje se v movementu

    public float move_speed;
    public float jump_force;

    [Header("Check Settings")]
    public LayerMask layer_ground;
    public BoxCollider2D check_ground;
    public BoxCollider2D check_left;
    public BoxCollider2D check_right;

    [Header("Ayes Settings")]
    public Transform look_ayes;
    public LayerMask look_mask;
    public float look_distance;

    [Header("Gun Settings")]
    public Transform gun_origin;
    public Transform gun_barell;
    public GameObject prefab_bullet;
    public AudioSource audio_shoot;
    public float aim_shootTime = 2;
    float aim_t;


    public bool isGrounded;
    public bool canMoveLeft;
    public bool canMoveRight;
    public bool sawPlayer;

    public Animator anim;

    int moveDir;
    int startMoveDir;
    Vector3 velocity;
    Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        startMoveDir = Mathf.RoundToInt(UnityEngine.Random.Range(-10,10)); 
        //z nějakýho důvodu to nefunguje s (-1,1), vrací to furt buďto -1 nebo 0 ._.
    }

    void Update()
    {
        
        SetMoveDir();
        EnvCheck();
        FlipDir();

        aim_t += Time.deltaTime;

    }
    void A_Shoot()
    {
        Instantiate(prefab_bullet,gun_barell.position,gun_barell.rotation);
    }
    void A_Aim()
    {   
       anim.SetBool("seePlayer",isSeeingPlayer());

        if(aim_t >= aim_shootTime)
        {
            anim.SetTrigger("shoot");
            aim_t = 0;

            audio_shoot.pitch = UnityEngine.Random.Range(0.9f,1.1f);
            audio_shoot.Play();
        }
    }   
    void A_LookAtPlayer()
    {
        if(player)
        {
            Vector3 relPoos = transform.position - player.position;
        
        float rot = Mathf.Atan2(relPoos.y,relPoos.x)*Mathf.Rad2Deg ;

        //správné otáčení zbraně
        if(transform.rotation.eulerAngles.y == 0)
        {
            rot -= 180;
        }
        else 
        {
            rot*=-1;
        }

        gun_origin.localRotation = Quaternion.Euler(0,0,rot);
        }
    }
    float playerSize = 1.2f;
    bool isSeeingPlayer()
    {
        if(player && Vector2.Distance(transform.position,player.position)<= look_distance)
        {
            for(int i = 1; i < 3;i++)
            {
                if(!Physics2D.Linecast(look_ayes.position,player.position + new Vector3(0,playerSize/i,0),look_mask))
                {
                    sawPlayer = true;
                    return true;
                }
            }
        }
        return false;
    }
    void SetMoveDir()
    {

        if(sawPlayer && player) //pokud vyděl hráče a hráč existuje
        {
            moveDir =  Mathf.RoundToInt(player.position.x - transform.position.x);
        } else
        {
            moveDir = startMoveDir;
        }
    


        moveDir = Mathf.Clamp(moveDir,-1,1);

    }
    void FlipDir()
    {
        if(moveDir >= 1)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if(moveDir <= -1)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
    }
    public void A_Move()
    {
        velocity = new Vector3();

        if(moveDir == 1 && canMoveRight)
        {
            velocity.x = moveDir *move_speed;
        }
        else if(moveDir == -1 && canMoveLeft)
        {
            velocity.x = moveDir *move_speed;
        }

        velocity.y = rig.velocity.y;

        A_JumpCheck();

        ApplyVelocity();



        anim.SetBool("seePlayer",isSeeingPlayer());
        
    }
    void ApplyVelocity()
    {
        rig.velocity = velocity;
    }

    void A_JumpCheck()
    {
        if(isGrounded &&!canMoveLeft||!canMoveRight)
        {
            Jump();
        }
    }
    void Jump()
    {
        velocity.y = jump_force;
    }
    void EnvCheck()
    {
        //uzemění
        if(Physics2D.OverlapBox((Vector2)transform.position+check_ground.offset,check_ground.size,0,layer_ground))
        {
            isGrounded = true;

        }
        else isGrounded = false;

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
    
}
