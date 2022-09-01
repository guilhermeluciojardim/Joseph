using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallExplosion : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision coll){
        if ((coll.gameObject.CompareTag("Spike")) || (coll.gameObject.CompareTag("Player"))){
            GameObject explosion = GameObject.Instantiate(explosionEffect, transform.position, transform.rotation) as GameObject;
            GameObject.Destroy(explosion, 1f);
            Destroy(gameObject);
            
        }
    }
}
