using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spacing")]
    public float spawnHight,spawnWight;
    [Header("Timing")]
    public float spawn_time;
    float time;
    [Header("Spawning asi")]
    public GameObject prefab_enemy;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= spawn_time)
        {
            time = 0;

            Spawn();
        }
    }
    void Spawn()
    {
        Vector3 randomPoos = new Vector3(transform.position.x + Random.Range(-spawnWight,spawnWight),spawnHight);

        Instantiate(prefab_enemy,randomPoos,Quaternion.identity);
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector3(-spawnWight+transform.position.x,spawnHight,0),new Vector3(spawnWight+transform.position.x,spawnHight,0));
    }
}

