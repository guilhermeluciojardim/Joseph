using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MultiTargetCameraMovement;

public class KeyItemActivation : MonoBehaviour
{
        public bool isActivated, isDoorClosed, isDoorClosing, isRevealing;
        float originalPositionY;
        [SerializeField] private GameObject Target;
        [SerializeField] private GameObject Boss;
        [SerializeField] private CameraMovement playerCam;
        [SerializeField] private GameObject revealEffect;
        [SerializeField] private GameObject NewAltar;
        public bool rightArm,leftArm;

        
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
                else if (gameObject.CompareTag("Arms")){
                    BreakArms();
                }
                else if (gameObject.CompareTag("Body")){
                    BreakBody();
                }
                else if (gameObject.CompareTag("Head")){
                    BreakHead();
                }
            }
        }

        void BreakArms(){
            isActivated=false;
            if (!leftArm){
                leftArm=true;
            }
            else if (!rightArm){
                rightArm=true;
                NewAltar.gameObject.SetActive(true);
                gameObject.SetActive(false);
            }   
        }
        void BreakBody(){
            isActivated=false;
            GameObject obj = GameObject.Instantiate(revealEffect, transform.position,transform.rotation) as GameObject;
            GameObject.Destroy(obj,2);
            Boss.transform.position = Target.transform.position;
            NewAltar.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        void BreakHead(){
            isActivated=false;
            GameObject obj = GameObject.Instantiate(revealEffect, transform.position,transform.rotation) as GameObject;
            GameObject.Destroy(obj,6);

            playerCam.AddTarget(NewAltar.transform);
            GameObject obj2 = GameObject.Instantiate(revealEffect, NewAltar.transform.position, NewAltar.transform.rotation) as GameObject;
            GameObject.Destroy(obj2,2);
            StartCoroutine(WaitForExitOpen());


        }
        IEnumerator WaitForExitOpen(){
            yield return new WaitForSeconds(2);
            playerCam.RemoveTarget(NewAltar.transform);
            NewAltar.SetActive(false);
            playerCam.RemoveTarget(Boss.transform);
            playerCam.offset.y = 5;
            playerCam.offset.z = 3;
            Destroy(Boss);
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
