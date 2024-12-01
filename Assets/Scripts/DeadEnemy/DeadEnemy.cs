using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer ren;
    void Start()
    {
        int random = Random.Range(0,sprites.Length);

        ren.sprite = sprites[random];
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
