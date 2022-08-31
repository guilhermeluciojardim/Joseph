using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MultiTargetCameraMovement;

public class KeyItemActivation : MonoBehaviour
{
        public bool isActivated, isDoorClosed, isDoorClosing;
        float originalPositionY;
        [SerializeField] private CameraMovement playerCam;
        [SerializeField] private LevelManager levelManager;
        
        void Start(){
            originalPositionY = transform.position.y;
        }   

        void Update(){
            if (isActivated){
                if (gameObject.CompareTag("Door")){
                    OpenDoor();
                }
            }
        }

        void OpenDoor(){
            if (!isDoorClosing){
                playerCam.AddTarget(transform);
                isDoorClosing=true;
                levelManager.ShowText("You found an altar of the lord \n \n press ENTER for pray");
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
}
