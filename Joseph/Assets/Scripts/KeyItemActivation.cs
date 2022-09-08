using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MultiTargetCameraMovement;

public class KeyItemActivation : MonoBehaviour
{
        public bool isActivated, isDoorClosed, isDoorClosing, isRevealing;
        float originalPositionY;
        [SerializeField] private CameraMovement playerCam;
        [SerializeField] private GameObject revealEffect;
        
        void Start(){
            originalPositionY = transform.position.y;
        }   

        void Update(){
            if (isActivated){
                if (gameObject.CompareTag("Door")){
                    OpenDoor();
                }
                else if(gameObject.CompareTag("SecretChest")){
                    RevealChest();
                }
                else if (gameObject.CompareTag("BridgeChain")){
                    BreakChain();
                }
            }
        }

        void OpenDoor(){
            if (!isDoorClosing){
                isDoorClosing=true;
                playerCam.AddTarget(transform);
            }
            else if (!isDoorClosed){
                if (transform.position.y > originalPositionY-3){
                    transform.Translate(Vector3.down * Time.deltaTime);
                }
                else{
                    isDoorClosed=true;
                    playerCam.RemoveTarget(transform);
                    isActivated=false;
                }
            }
        }

        void RevealChest(){
            if (!isRevealing){
                isRevealing=true;
                playerCam.AddTarget(transform);
                gameObject.SetActive(true);
                GameObject obj = GameObject.Instantiate(revealEffect, transform.position,transform.rotation) as GameObject;
                GameObject.Destroy(obj,2);
            }
            else{
                isActivated=false;
                StartCoroutine(WaitForRemovecamera());
            }
        }
        void BreakChain(){
            isActivated=false;
            StartCoroutine(WaitForRemovecamera());
            gameObject.SetActive(false);
        }
        

        IEnumerator WaitForRemovecamera(){
            yield return new WaitForSeconds(2);
            playerCam.RemoveTarget(transform);

        }

        
}
