using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public ParticleSystem dust;
    //bool to check for iframes
    public bool isInvincible;

    //variables for default movement speed, the rigid body, and movement vector
    public float speed;
    public Rigidbody2D rb;
    private Vector2 move;

    //variables to track the current movement speed and dash speed
    private float activeMoveSpeed;
    public float dashSpeed;

    //dashing cooldown variables and counters
    public float dashLength = 0.5f;
    public float dashCooldown = 1f;
    private float dashCount;
    private float dashCoolCount;

    // Start is called before the first frame update
    void Start()
    {
        //set movement speed
        activeMoveSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        //get the movement inputs from user
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        move.Normalize();

        //give the rigidbody a velocity based on the current activeMoveSpeed
        rb.velocity = move * activeMoveSpeed;

        //if the space abr is being pressed the movement speed is equal to the dash speed
        //aka dash initiated
        if(Input.GetKeyDown(KeyCode.Q)){
            activeMoveSpeed = dashSpeed;
            dashCount = dashLength;

            createDust();
            //iframe
            isInvincible = true;
        }


        //Cooldown stuff vvvvv
        if(dashCount > 0){
            dashCount -= Time.deltaTime;
            if(dashCount <= 0){
                activeMoveSpeed = speed;
                dashCoolCount = dashCooldown;
                isInvincible = false;
            }
        }

        if(dashCoolCount > 0){
            dashCoolCount -= Time.deltaTime;
        }
    }

    //bad collision detection 
    void OnCollision(Collision2D coll){
        rb.velocity = Vector2.zero;
    }

    void createDust(){
        dust.Play();
        
    }

}
