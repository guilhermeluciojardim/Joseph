using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyShotBehavior : MonoBehaviour
{
    [SerializeField] private float shotSpeed;
    [SerializeField] private GameObject explosionEffect;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * shotSpeed);
    }

    void OnCollisionEnter(Collision coll){
        GameObject obj = Instantiate(explosionEffect,transform.position, transform.rotation) as GameObject;
        GameObject.Destroy(obj,2);
        Destroy(gameObject);
    }
}
