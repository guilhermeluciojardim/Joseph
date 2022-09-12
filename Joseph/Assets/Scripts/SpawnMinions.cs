using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMinions : MonoBehaviour
{
    [SerializeField] private GameObject mummy;

    public float time;
    public bool isActivated;

    void Start(){
        time=30f;
    }
    // Update is called once per frame
    void Update()
    {
        if  (isActivated){
            InvokeRepeating("SpawnMummy",1f,time);
            isActivated=false;
        }
        
    }

    void SpawnMummy(){
        Instantiate(mummy,transform.position,transform.rotation);
    }
}
