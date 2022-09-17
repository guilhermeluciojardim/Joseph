using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;
    // Start is called before the first frame update
   void OnCollisionEnter(Collision coll){
        if (coll.gameObject.CompareTag("TrapSpear")){
            healthSystem.TakeDamage(5f);
        }
        if (coll.gameObject.CompareTag("FireGround")){
            healthSystem.TakeDamage(healthSystem.maxHitPoint);
        }
        if (coll.gameObject.CompareTag("FireBall")){
            healthSystem.TakeDamage(20f);
        }
        if (coll.gameObject.CompareTag("Spike")){
            healthSystem.TakeDamage(5f);
        }
       
         if (coll.gameObject.CompareTag("Skull")){
            healthSystem.TakeDamage(3f);
        }
         if (coll.gameObject.CompareTag("TrapBlade")){
            healthSystem.TakeDamage(10f);
        }
        
   }
   void OnParticleCollision(GameObject coll){
    if (coll.gameObject.CompareTag("FlameThrower")){
            healthSystem.TakeDamage(1f);
    }
   }
}
