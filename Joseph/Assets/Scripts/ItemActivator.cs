using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActivator : MonoBehaviour
{
[SerializeField] private GameObject activatedObject;

  void OnTriggerEnter(Collider coll){
    if (coll.gameObject.CompareTag("Player")){
            KeyItemActivation item = activatedObject.GetComponent<KeyItemActivation>();
            item.isActivated = true;
    }
  }
}
