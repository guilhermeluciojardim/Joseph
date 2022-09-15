using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MultiTargetCameraMovement;

public class ActivateBoss : MonoBehaviour
{
    [SerializeField] private GameObject bridge;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private GameObject bridgeHolder;
    [SerializeField] private CameraMovement mainCamera;
    [SerializeField] private GameObject Boss;
    [SerializeField] private GameObject SpawnPoint1;
    [SerializeField] private GameObject SpawnPoint2;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll){
        if (coll.gameObject.CompareTag("Player")){
            mainCamera.AddTarget(bridge.transform);
            GameObject exp = Instantiate(explosionEffect,bridge.transform.position,bridge.transform.rotation) as GameObject;
            GameObject.Destroy(exp,1f);
            bridge.GetComponent<Rigidbody>().isKinematic = false;
            bridgeHolder.gameObject.SetActive(false);

            StartCoroutine(WaitForBridge());
        }
    }

    IEnumerator WaitForBridge(){
        mainCamera.RemoveTarget(bridge.transform);
        yield return new WaitForSeconds(3f);
        Boss.gameObject.SetActive(true);
        mainCamera.AddTarget(Boss.transform);
        mainCamera.offset.y = 10;
        mainCamera.offset.z = 5;
        SpawnPoint1.GetComponent<SpawnMinions>().isActivated=true;
        SpawnPoint2.GetComponent<SpawnMinions>().isActivated=true;

        Destroy(bridge);
        Destroy(gameObject);
    }
}
