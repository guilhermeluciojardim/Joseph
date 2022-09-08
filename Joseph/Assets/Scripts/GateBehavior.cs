using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehavior : MonoBehaviour
{
    [SerializeField] private GameObject chain1;
    [SerializeField] private GameObject chain2;

    private float closeSpeed, originalPos, targetPos;
    private bool isFirstHalfOpen, isSecondHalfOpen;

    void Start(){
        originalPos = 1f;
        targetPos = 3f;
        closeSpeed = 30f;
    }
    // Update is called once per frame
    void Update()
    {
        if (chain1.gameObject.activeSelf == false){
            originalPos += Time.deltaTime * closeSpeed;
            
            if ((originalPos < targetPos) && (!isFirstHalfOpen)){
                transform.Translate(Vector3.up * Time.deltaTime * closeSpeed);
            }
            else{
                originalPos=0;
                isFirstHalfOpen= true;
            } 
        }
        if (chain2.gameObject.activeSelf == false){
            originalPos += Time.deltaTime * closeSpeed;
            
            if ((originalPos < targetPos) && (!isSecondHalfOpen)){
                transform.Translate(Vector3.up * Time.deltaTime * closeSpeed);
            }
            else {
                originalPos=0;
                isSecondHalfOpen=true;
            }
        }
        if (isFirstHalfOpen && isSecondHalfOpen){
            Destroy(gameObject);
        }
    }
}
