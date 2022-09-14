using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSphereAround : MonoBehaviour
{
    [SerializeField] private GameObject TargetObj;
    public float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
       transform.RotateAround(TargetObj.transform.position, Vector3.up * Time.deltaTime, rotateSpeed);
    }
}
