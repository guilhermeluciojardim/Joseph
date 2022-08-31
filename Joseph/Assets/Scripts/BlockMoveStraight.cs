using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoveStraight : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform BoundaryZ1, BoundaryZ2;

    Vector3 target; 
    void Start(){
        target=BoundaryZ1.position;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        float distToBoundaryZ1 = Vector3.Distance(pos,BoundaryZ1.position);
        float distToBoundaryZ2 = Vector3.Distance(pos,BoundaryZ2.position);

        if (distToBoundaryZ1 == 0){
            target = BoundaryZ2.position;
        }
        else if (distToBoundaryZ2 == 0){
            target = BoundaryZ1.position;
        }
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        
       
    }
    void OnCollisionEnter (Collision coll) {
        if (coll.gameObject.CompareTag("Player")){
            coll.transform.SetParent(transform);
        } 
    }

    void OnCollisionExit (Collision coll){
        if (coll.gameObject.CompareTag("Player")){
            coll.transform.SetParent(null);
        }
    }
}
