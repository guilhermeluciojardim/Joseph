using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBehavior : MonoBehaviour
{
    [SerializeField] private GameObject chain1;
    [SerializeField] private GameObject chain2;

    private bool isBridgeDown;

    // Update is called once per frame
    void Update()
    {
        if (!isBridgeDown){    
            if (chain1.activeSelf == false && chain2.activeSelf == false){
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                isBridgeDown = true;
                StartCoroutine(WaitForBridgeDown());
            }
        }
    }

    IEnumerator WaitForBridgeDown(){
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
