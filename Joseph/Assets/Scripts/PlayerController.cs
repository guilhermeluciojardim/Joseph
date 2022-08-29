using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using MultiTargetCameraMovement;

public class PlayerController : MonoBehaviour
{
    //Variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    public bool isDead,isJumping;
    private int health, maxHealth;
    private Vector3 moveDirection;
    private Vector3 velocity;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;

   //References
    private CharacterController controller;
    private Animator anim;
    private CameraMovement playerCam;
 

    private void Start(){ 
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        playerCam = GetComponentInChildren<CameraMovement>();
        Cursor.lockState = CursorLockMode.Locked;
       
    }
    private void Update(){
        Move();
    }

    
    private void Move(){
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if ((isGrounded) && (velocity.y < 0)){
            velocity.y = -2f;
        }
        float moveZ = Input.GetAxis("Vertical");
        float rotY = 1.5f * Input.GetAxis("Horizontal");
        float tawY = Input.GetAxis("Mouse Y");

        transform.Rotate(0,rotY,0);
        
        moveDirection = new Vector3(0,0,moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded){
            anim.SetBool("isJumping",false);
            isJumping=false;
            anim.SetBool("isFalling",false);
            anim.SetBool("isGrounded",true);
            anim.SetBool("isMoving",true);
            
            if ((moveDirection != Vector3.zero) && (!Input.GetKey(KeyCode.LeftShift))){
                if (moveZ<0){
                    WalkBackAnim();
                }
                else{
                    WalkAnim();
                }
                
            }
            else if ((moveDirection != Vector3.zero) && (Input.GetKey(KeyCode.LeftShift)) && (moveZ > 0)){
                RunAnim();
            }
            else if (moveDirection == Vector3.zero){
                IdleAnim();
            }
            
            if (Input.GetKeyDown(KeyCode.Space)){
                JumpAnim();
            }
            if ((Input.GetKeyDown(KeyCode.LeftControl)) && (moveZ > 0)){
                RollAnim();
            }
            moveDirection *= moveSpeed;
        }
        else{
            anim.SetBool("isGrounded",false);

            if (isJumping && velocity.y <= 0 || velocity.y < -2) {
                anim.SetBool("isFalling", true);
                anim.SetBool("isJumping",false);
            }

        }     
        controller.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void IdleAnim(){
        anim.SetFloat("Speed", 0,0.1f,Time.deltaTime);
    }
    private void WalkAnim(){
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f,0.1f,Time.deltaTime);
    }
    private void WalkBackAnim(){
        moveSpeed = walkSpeed/4;
        anim.SetFloat("Speed", 0.35f,0.1f,Time.deltaTime);
    }
    private void RunAnim(){
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1f,0.1f,Time.deltaTime);
    }
    private void JumpAnim(){
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        anim.SetBool("isJumping",true);
        isJumping=true;
    }
    private void RollAnim(){
        moveSpeed = runSpeed;
        anim.SetTrigger("Roll");
    }
}
