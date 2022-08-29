using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
 

    private void Start(){ 
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
       
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
        float moveX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(moveX,0,moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded){
            anim.SetBool("isJumping",false);
            isJumping=false;
            anim.SetBool("isFalling",false);
            anim.SetBool("isGrounded",true);
            anim.SetBool("isMoving",true);
            
            if ((moveDirection != Vector3.zero) && (!Input.GetKey(KeyCode.LeftShift))){
                WalkAnim();
            }
            else if ((moveDirection != Vector3.zero) && (Input.GetKey(KeyCode.LeftShift))){
                RunAnim();
            }
            else if (moveDirection == Vector3.zero){
                IdleAnim();
            }
            moveDirection *= moveSpeed;
            if (Input.GetKeyDown(KeyCode.Space)){
                JumpAnim();
                isJumping=true;
            }
        }
        else{
            anim.SetBool("isGrounded",false);

            if (isJumping && velocity.y < 0 || velocity.y < -2) {
                anim.SetBool("isFalling", true);
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
    private void RunAnim(){
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1f,0.1f,Time.deltaTime);
    }
    private void JumpAnim(){
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        anim.SetBool("isJumping",true);
        isJumping=true;
    }
}
