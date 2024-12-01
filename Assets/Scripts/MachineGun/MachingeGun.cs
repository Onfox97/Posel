using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachingeGun : MonoBehaviour
{
    public float gun_reach;

    public float gun_shootSpeed;
    float gun_t;
    public List<Transform> Targets = new List<Transform>();

    public GameObject gun_bullet;
    public Transform gun_body;
    public Transform gun_barell;

    public AudioSource audio_shoot;
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        UpdateTargetList();

        if(Targets.Count > 0)
        {
            LookAtTarget();
            Shoot();

            anim.SetBool("Shoot",true);
        }
        else
        {
            anim.SetBool("Shoot",false);
        }
    }
    void UpdateTargetList()
    {
        Targets.Clear();

        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in allEnemies)
        {
            if(Vector2.Distance(enemy.transform.position,transform.position) <= gun_reach)
            {
                Targets.Add(enemy.transform);
            }
        }
    }

    void LookAtTarget()
    {
        Vector3 relativePosition = Targets.ToArray()[0].position - transform.position;

        float angle = Mathf.Atan2(relativePosition.y,relativePosition.x) * Mathf.Rad2Deg;

        gun_body.transform.rotation = Quaternion.Euler(0,0,angle);
    
    }
    void Shoot()
    {
        gun_t += Time.deltaTime;

        if(gun_t >= gun_shootSpeed)
        {
            gun_t = 0;

            Instantiate(gun_bullet,gun_barell.position,gun_barell.rotation);

            audio_shoot.pitch = Random.Range(0.9f,1.1f);

            audio_shoot.Play();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position,gun_reach);
    }
}
