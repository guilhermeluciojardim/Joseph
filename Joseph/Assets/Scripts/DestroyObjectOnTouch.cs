using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOnTouch : MonoBehaviour
{
    void OnTriggerEnter(Collider coll){
        if (coll.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
