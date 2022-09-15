using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyHealth : MonoBehaviour
{
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private GameObject damageEffect;
   public float health;
   void Start(){
        health=100;
   }
   void OnCollisionEnter(Collision coll){
        if (coll.gameObject.CompareTag("Weapon")){
            CreateDamageEffect();
            health-=25;
            if (health<0){
                CreateDeathEffect();
                Destroy(gameObject);
            }
        }
   }
   void OnParticleCollision(GameObject coll){
        if (coll.gameObject.CompareTag("Magic")){
            CreateDeathEffect();
            Destroy(gameObject);
        }
   }

   void CreateDeathEffect(){
    GameObject exp = Instantiate(deathEffect,transform.position,transform.rotation) as GameObject; 
    GameObject.Destroy(exp,2f);
   }

   void CreateDamageEffect(){
    GameObject exp = Instantiate(damageEffect,transform.position,transform.rotation) as GameObject; 
    GameObject.Destroy(exp,1f);
   }

  
}
