using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public bool Activate, isOpen, isClosed, isMoving;
    private float angle;

    [SerializeField] private float speed;
    [SerializeField] private GameObject lid;

    void Start(){
        isClosed=true;
        isOpen=false;
        isMoving=false;
        Activate=false;
    }

    void Update()
    {   
        if (Activate){
            if (isOpen){
                Close();
            }
            else if (isClosed){
                Open();
            }
        }
    }

    private void Open(){
            lid.transform.Rotate(Vector3.left * Time.deltaTime * speed);
            angle += Time.deltaTime * speed;
            if (angle > 90){
                isOpen=true;
                isClosed=false;
                Activate=false;
                isMoving=false;
                angle=0;
            }
    }

    private void Close(){
            lid.transform.Rotate(Vector3.right * Time.deltaTime * speed);
            angle += Time.deltaTime * speed;
            if (angle > 90){
                isClosed=true;
                isOpen=false;
                Activate=false;
                isMoving=false;
                angle=0;
            }
                
            
    }

    void OnCollisionStay(Collision coll){
        if ((coll.gameObject.CompareTag("Player")) && (Input.GetKeyDown(KeyCode.Return)) && (!isMoving)){
            Activate=true;
            isMoving=true;
        }
    }
}
