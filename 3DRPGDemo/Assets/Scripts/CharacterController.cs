
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public int speed;
    private const int WALK_SPEED = 4;
    private const int RUN_SPEED = 8;
    public bool runToggle = false;

    public static char facing = 's';
    public bool pause_flag = false;

    public Rigidbody rbody;
    public Animator anim;
     
    void Awake() 
    {
        //rbody = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
        speed = WALK_SPEED;
    }
      
    void Update()
    {
        if(!pause_flag) {
            //No Movement Facing Animations
            if(rbody.velocity == Vector3.zero)
            {
                if(facing == 'n') {
                    anim.SetInteger("moveState", 0);
                }
                else if(facing == 'e') {
                    anim.SetInteger("moveState", 1);
                }
                else if(facing == 's') {
                    anim.SetInteger("moveState", 2);
                }
                else if(facing == 'w') {
                    anim.SetInteger("moveState", 3);
                }
                
            }

            //Run Toggle on Left SHif
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if(runToggle == false) {
                    speed = RUN_SPEED;
                    runToggle = true;
                }
                else {
                    speed = WALK_SPEED;
                    runToggle = false;
                }
            }
        }
        
    }

      void FixedUpdate()
      {
        if(!pause_flag) {
            //Recieve Input
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");
            //Movement
            move(rbody, x, z);
        }
      }
      
    void move(Rigidbody rb, float x, float z)
    {

        if (x > 0.5f || x < -0.5f) {
            if(x > 0) {
                if(runToggle == false) {
                    anim.SetInteger("moveState", 5); //Walk Right
                }
                else {
                    anim.SetInteger("moveState", 9); //Run Right
                }
                facing = 'e';
            }
            else if (x < 0) {
                if(runToggle == false) {
                    anim.SetInteger("moveState", 7); //Walk Left
                }
                else {
                    anim.SetInteger("moveState", 11); //Run Left
                }
                facing = 'w';
            }
            else
            {
                anim.SetInteger("moveState", 0);
            }

            //Update Velocity
            rb.velocity = new Vector3(x*speed, 0, 0);
        }
        else if (z > 0.5f || z < -0.5f) {
            if(z > 0) {
                if(runToggle == false) {
                    anim.SetInteger("moveState", 4); //Walk Up
                }
                else {
                    anim.SetInteger("moveState", 8); //Run Up
                }
                facing = 'n';
            }
            else if (z < 0) {
                if(runToggle == false) {
                    anim.SetInteger("moveState", 6); //Walk Down
                }
                else {
                    anim.SetInteger("moveState", 10); //Run Down
                }
                facing = 's';   
            }
            else {
                anim.SetInteger("moveState", 0); 
            }
            rb.velocity = new Vector3(0, 0, z*speed);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
      }

    //Return char of direcrtion player is facing
    public static char getFacing()
    {
        return facing;
    }
}

