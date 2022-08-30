using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoveStraight : MonoBehaviour
{
    private int dir;
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
    void OnCollisionStay (Collision coll) {
        foreach (ContactPoint contact in coll.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal * 10, Color.white);
        }
        if (coll.gameObject.CompareTag("Player")){
            Debug.Log("Touch");
            Vector3 pos = transform.position;
            Vector3 dir = (pos - target).normalized;
            coll.transform.Translate(dir);
        } 
    }
}
