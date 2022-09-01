using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPushPlayer : MonoBehaviour
{
    private Vector3 velocity;
    [SerializeField] private float pushForce;
    [SerializeField] private CharacterController controller;
    

    void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.CompareTag("Player")){
            velocity.z = Mathf.Sqrt(pushForce * -2);
            controller.Move(velocity * Time.deltaTime); 
        }
       
    }
}
