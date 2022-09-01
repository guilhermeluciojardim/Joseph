using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireballManager : MonoBehaviour
{
   
    [SerializeField] private GameObject fireballPrefab;
    // Update is called once per frame

    void Start(){
        InvokeRepeating("ReleaseFireball", 0.7f, 0.7f);
    }
    void Update()
    {
        Vector3 newPos = new Vector3 (Random.Range(-17.5f,-38.5f),10,-24);
        transform.position = newPos;
    }

    void ReleaseFireball(){
        Instantiate(fireballPrefab, transform.position, transform.rotation);
    }
}
