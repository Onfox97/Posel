using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bullet_speed;
    public float bullet_gravity;
    public float bullet_startRandomOffset;
    public LayerMask bullet_hitMask;

    Vector3 velocity;
    void Start()
    {
        Destroy(gameObject,2f);

        Vector3 randomRot = new Vector3(0,0,Random.Range(-bullet_startRandomOffset,bullet_startRandomOffset));
        randomRot += transform.rotation.eulerAngles;

        transform.rotation = Quaternion.Euler(randomRot);

        velocity = transform.right * bullet_speed;


    }
    void FixedUpdate()
    {
        MoveBullet();
        CollisionCheck();
    }

    void MoveBullet()
    {
        velocity += Vector3.down * bullet_gravity * Time.fixedDeltaTime * Time.fixedDeltaTime;
        
        transform.position += velocity * Time.fixedDeltaTime;
    }
    void CollisionCheck()
    {
        RaycastHit2D hit;

        float bulletTraverDistance = bullet_speed * Time.fixedDeltaTime;
        hit = Physics2D.Raycast(transform.position-transform.right * bulletTraverDistance,transform.right,bulletTraverDistance,bullet_hitMask);

        if(hit)
        {
            transform.position = hit.point;
            Health hitHealth = hit.collider.GetComponent<Health>();

            if(hitHealth != null)
            {
                hitHealth.Hit();
            }

            Destroy(gameObject,0.01f);
        }
    }
}
