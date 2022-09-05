using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereActivator : MonoBehaviour
{
    private string Status;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private GameObject sparkEffect;
    [SerializeField] private GameObject activatedObject;

    void Start(){
        Status = "Green";
        
    }
   void OnCollisionEnter(Collision coll){
    if (coll.gameObject.CompareTag("Weapon")){
        if (Status== "Green"){
            Status = "Yellow";
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            GameObject spark = Instantiate(sparkEffect,transform.position,transform.rotation) as GameObject;
            GameObject.Destroy(spark,0.2f);
        }
        else  if (Status== "Yellow"){
            Status = "Red";
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            GameObject spark = Instantiate(sparkEffect,transform.position,transform.rotation) as GameObject;
            GameObject.Destroy(spark,0.2f);
        }
        else{
            GameObject explosion = Instantiate(explosionEffect,transform.position,transform.rotation) as GameObject;
            GameObject.Destroy(explosion,2f);
            activatedObject.gameObject.GetComponent<KeyItemActivation>().isActivated = true;
            Destroy(gameObject);
            
        }
    }
   }
}
