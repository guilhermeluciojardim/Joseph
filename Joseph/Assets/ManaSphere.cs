using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSphere : MonoBehaviour
{
    private HealthSystem Mana;
    private GameObject[] HealthSystem;
    // Start is called before the first frame update
    void Start(){
        HealthSystem = GameObject.FindGameObjectsWithTag("HealthSystem");
        Mana = HealthSystem[0].GetComponent<HealthSystem>();
    }
    void OnTriggerEnter(Collider coll){
        if (coll.gameObject.CompareTag("Player")){
            Mana.RestoreMana(20);
            Destroy(gameObject);
        }
    }  
       
}
