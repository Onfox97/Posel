using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute : MonoBehaviour
{
    public float fallSpeed;

    public GameObject prefab_spawnOnLanding;
    Rigidbody2D rig;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rig.velocity = new Vector2(rig.velocity.x,fallSpeed);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(prefab_spawnOnLanding,transform.position,Quaternion.identity);

        Destroy(gameObject);
    }
}
