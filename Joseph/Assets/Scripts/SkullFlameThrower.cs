using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullFlameThrower : MonoBehaviour
{
    [SerializeField] private GameObject flameEffect;
    void Start()
    {
        InvokeRepeating("FlamesOn",10f,10f);
        InvokeRepeating("FlamesOff",5f,10f);
    }
    void FlamesOn(){
        flameEffect.GetComponent<ParticleSystem>().Play();
    }
    void FlamesOff(){
        flameEffect.GetComponent<ParticleSystem>().Stop();
    }
}
