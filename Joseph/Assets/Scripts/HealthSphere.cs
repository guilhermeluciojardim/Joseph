using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSphere : MonoBehaviour
{
    private HealthSystem Health;
    private GameObject[] HealthSystem;
    // Start is called before the first frame update
    void Start(){
        HealthSystem = GameObject.FindGameObjectsWithTag("HealthSystem");
        Health = HealthSystem[0].GetComponent<HealthSystem>();
    }
    void OnTriggerEnter(Collider coll){
        if (coll.gameObject.CompareTag("Player")){
            Health.HealDamage(10);
            Destroy(gameObject);
        }
    }
}
