
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int health_points = 1;
    public GameObject prefab_dropOnDeath;
    public bool eventOnHit = false;
    public UnityEvent onHit;

    public void Hit(int damagePoints = 1)
    {
        health_points -= damagePoints;

        if(eventOnHit) onHit.Invoke();
        
        if(health_points <= 0) 
        {
            if(prefab_dropOnDeath)Instantiate(prefab_dropOnDeath,transform.position,Quaternion.identity);
            
            Destroy(gameObject);
        }
    }

    
    
}
