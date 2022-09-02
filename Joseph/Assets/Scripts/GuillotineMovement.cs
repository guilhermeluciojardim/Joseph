using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuillotineMovement : MonoBehaviour
{
    private float angle;

    [SerializeField] private float speed;
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (dir == Vector3.forward){angle += Time.deltaTime * speed;}
        else if (dir == Vector3.back){angle -= Time.deltaTime * speed;}

        transform.Rotate(dir * Time.deltaTime * speed);

        if (angle > 30){
            angle = 30;
            dir = Vector3.back;
        }
        else if (angle < -30){
            angle=-30;
            dir= Vector3.forward;
        }
    }

    
}
