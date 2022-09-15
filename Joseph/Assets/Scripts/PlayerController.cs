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
    [SerializeField] private HealthSystem manaSystem;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    public bool isDead,isJumping, isAttacking;
    private int health, maxHealth;
    private Vector3 moveDirection;
    private Vector3 velocity;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;

    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject magicEffect;
    [SerializeField] private Transform magicOrigin;
    [SerializeField] private RuntimeAnimatorController newController;
    private MeshCollider weaponMesh;

   //References
    private CharacterController controller;
    private Animator anim;
    private CameraMovement playerCam;

    private float magicCost;

 

    private void Start(){ 
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        playerCam = GetComponentInChildren<CameraMovement>();
        Cursor.lockState = CursorLockMode.Locked;
        weaponMesh = weapon.GetComponent<MeshCollider>();
        magicCost = 5f;
    }
    private void Update(){
        Move();
        Attack();
    }

    
    private void Move(){
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if ((isGrounded) && (velocity.y < 0)){
            velocity.y = -2f;
        }
        float moveZ = Input.GetAxis("Vertical");
        float rotY = 3f * Input.GetAxis("Mouse X");

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

    void Attack(){
        if (weapon.activeSelf == true){
            if (Input.GetKeyDown(KeyCode.Mouse0)){
                    StartCoroutine(WaitForMesh());
                    anim.SetBool("Attack1",true);
                    StartCoroutine(WaitForNextAttack());
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1)){
                    if (!isAttacking){
                        isAttacking=true;
                        weaponMesh.enabled=true;
                        anim.SetBool("Attack2",true);
                        if (manaSystem.manaPoint>=magicCost){
                            manaSystem.UseMana(magicCost);
                            GameObject magic = Instantiate(magicEffect,magicOrigin.position, transform.rotation);
                            GameObject.Destroy(magic,3f);
                        }
                        StartCoroutine(WaitForNextAttack());
                    }
                   
                    
            }
            
        }
    }
     IEnumerator WaitForMesh(){
        yield return new WaitForSeconds(0.2f);
        weaponMesh.enabled=true;
    }
    IEnumerator WaitForNextAttack(){
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Attack1",false);
        anim.SetBool("Attack2",false);
        weaponMesh.enabled=false;
        isAttacking=false;
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

    public void GivePlayerHisWeapon(){
        weapon.gameObject.SetActive(true);
        anim.runtimeAnimatorController = newController;
    }
}
