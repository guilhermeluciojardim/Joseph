using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeadAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private bool isAnimationExecuted = false;
  
    void OnCollisionEnter(Collision coll){
        if (!isAnimationExecuted){
            if (coll.gameObject.CompareTag("Player")){
                anim.SetBool("isDead",true);
                isAnimationExecuted=true;
                StartCoroutine(WaitToDead());
            }
        }
    }

    IEnumerator WaitToDead(){
        yield return new WaitForSeconds(2);
        anim.SetBool("isDead",false);
        anim.SetBool("GetUp",true);
        StartCoroutine(WaitToGetUp());
    }
    
    IEnumerator WaitToGetUp(){
        yield return new WaitForSeconds(2);
        anim.SetBool("GetUp",false);
        anim.SetBool("isMoving",true);
    }
}
