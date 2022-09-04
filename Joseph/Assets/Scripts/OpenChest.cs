using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public bool Activate, isOpen, isClosed, isMoving, isEmpty;
    private float angle;

    [SerializeField] private float speed;
    [SerializeField] private GameObject lid;
    [SerializeField] private GameObject content;

    void Start(){
        isClosed=true;
        isOpen=false;
        isMoving=false;
        Activate=false;
        if (content == null){
            isEmpty=true;    
        }
        else{
            isEmpty=false;
        }
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
                if (!isEmpty){
                    GameObject cont = Instantiate(content,transform.position + new Vector3(0,1,0),content.transform.rotation) as GameObject;
                    GameObject.Destroy(cont,3f);
                    isEmpty=true;
                    if (cont.gameObject.CompareTag("Weapon")){
                        GameObject[] player =  GameObject.FindGameObjectsWithTag("Player");
                        player[0].gameObject.GetComponent<PlayerController>().GivePlayerHisWeapon();
                    }
                }
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
        if ((coll.gameObject.CompareTag("Player")) && (Input.GetKeyDown(KeyCode.E)) && (!isMoving)){
            Activate=true;
            isMoving=true;
        }
    }



}
