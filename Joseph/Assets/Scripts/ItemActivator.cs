using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActivator : MonoBehaviour
{
[SerializeField] private GameObject activatedObject;

  void OnCollisionEnter(Collision coll){
    if (coll.gameObject.CompareTag("Player")){
            Debug.Log("Touch");
            KeyItemActivation item = activatedObject.GetComponent<KeyItemActivation>();
            item.isActivated = true;
    }
  }
}
