using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAnimHandler : MonoBehaviour
{
    public Animator anim;
    public PlayerMove2D move;
    public PlayerGun gun;
    public Rigidbody2D rigidbody_player;
    void Update()
    {
        anim.SetBool("isMoving",move.move_isMovning);
        anim.SetBool("isAiming",gun.isAiming);
        anim.SetBool("isCrouching",move.crouch_isCrouching);

        int fallDir = Mathf.RoundToInt(rigidbody_player.velocity.normalized.y);

        anim.SetInteger("Fall", fallDir);

    }
    public void Shoot()
    {
        anim.SetTrigger("Shoot");
    }
    public void ShootFromHip()
    {
        anim.SetTrigger("ShootFromHip");
    }
}
