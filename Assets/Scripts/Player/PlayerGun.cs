using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public PlayerMove2D playerMove;
    public PlayerAnimHandler animHandler;

    public Transform gun;
    public Transform gun_barell;
    public GameObject prefab_bullet;

    public float aim_speed;
    public float shoot_speed;


    float shoot_t;
    float aimPitch;

    [Header("keycodes")]
    public KeyCode key_aim = KeyCode.A;
    public KeyCode key_shoot = KeyCode.S;

    public KeyCode key_aimUp = KeyCode.UpArrow;
    public KeyCode key_aimDown = KeyCode.DownArrow;

    public bool isAiming;
    public PlayerSound sound;

    void Update()
    {
        //AIM
        if(Input.GetKey(key_aim) && !playerMove.crouch_isCrouching && playerMove.isPlayerGrounded)
        {   
            if(isAiming)
            {
                Aim();
            }
            else
            {
                AimStart();
            }
            
            
        }
        else if(Input.GetKeyUp(key_aim) && isAiming) AimStop();

        
        if(Input.GetKeyDown(key_shoot))
        {
            if(isAiming)
            {
                Shoot();
            }
            //else ShootFromHip();
        }
        shoot_t -= Time.deltaTime;
    }

    void Shoot()
    {
        if(shoot_t <= 0)
        {
            Instantiate(prefab_bullet,gun_barell.position,gun_barell.rotation);
            shoot_t = shoot_speed;

            animHandler.Shoot();

            sound.Shoot();
        }
    }
    void ShootFromHip()
    {
        if(shoot_t <= 0)
        {
            aimPitch = 0;
            Aim();

            Instantiate(prefab_bullet,gun_barell.position,gun_barell.rotation);
            shoot_t = shoot_speed;

            animHandler.Shoot();
        }
    }


    void AimStart()
    {
        playerMove.enabled = false;
        isAiming = true;

        aimPitch = 0;
    }
    void Aim()
    {
        //míření nahoru a dolů
        aimPitch += AimAxis() * aim_speed * Time.deltaTime;

        aimPitch = Mathf.Clamp(aimPitch,-65,65);

        gun.transform.localRotation = Quaternion.Euler(0,0,aimPitch);

        //míření do stran
        playerMove.SetMoveAxis();
        playerMove.FlipDir();
    }
    void AimStop()
    {
        playerMove.enabled = true;
        isAiming = false;
    }
    int AimAxis()
    {
        int aim = 0;

        if(Input.GetKey(key_aimUp))
        {
            aim = 1;
        }
        else if (Input.GetKey(key_aimDown))
        {
            aim = -1;
        }

        return aim;
    }


}
