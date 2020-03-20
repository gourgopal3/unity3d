using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{


    public CharacterController ctrl;
    public float speed = 20f;


    //for gravity
    Vector3 velocity;
     public  float gravity=-9.81f;


    //for ground check
    public Transform ground;
    public float grounddistance = 0.4f;
    public LayerMask groundlayer;
    bool isground;

    //jump
    public float jumpheight = 2f;

   
   
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        playermove();
        player_velocity();
        groundcheck();
    }


    void playermove() {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move_player = transform.right * x + transform.forward * z;

        ctrl.Move(move_player*speed*Time.deltaTime);
        


    }

    void player_velocity() {

        velocity.y += gravity * Time.deltaTime;

        ctrl.Move(velocity * Time.deltaTime);
    }

    void groundcheck() {

        isground = Physics.CheckSphere(ground.position,grounddistance,groundlayer);

        if (isground && velocity.y < 0f) {

           velocity.y = -9f;

        }
        if (Input.GetButtonDown("Jump") && isground)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);

        }
        //my super jump
        if (Input.GetButtonDown("test1")&&isground) {
            float superjump  = 10f;
            velocity.y = Mathf.Sqrt(superjump * -2f * gravity);

        }

    }

}
