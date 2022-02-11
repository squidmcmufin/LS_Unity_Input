using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Input : MonoBehaviour
{
    private float movespeed = 4.0f;

    private float Dashmultiplier = 1.5f;

    private Vector3 StartCoords = new Vector3(0.0f, 0.0f, 0.0f);

    private Vector3 PreviousPosition = new Vector3(0.0f, 0.0f, 0.0f);

    public   bool grounded = false;

    private bool jumping = false;

    private float jumptime = 1.0f;
    private float jumptime_current = 0.0f;

    public Rigidbody rb;

    public Vector3 jump;

    private Vector3 jump_current;
    private float jumpforce = 0.5f;
    private float gravityforce = 0.6f;
    private float gravitycurrent = 0f;
    public GameObject standingonground;
    void Start()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        StartCoords = transform.position;

        jump = new Vector3 (0.0f, 2.0f, 0.0f);

        jump_current = new Vector3(0.0f, 0.0f, 0.0f);

    }

    void Update()
    {
        PreviousPosition = transform.position;


        float horizontalInput = Input.GetAxis("Horizontal") + Input.GetAxis("Horizontal_Keyboard");

        float verticalInput = (-Input.GetAxis("Vertical")) + (-Input.GetAxis("Vertical_Keyboard"));



        var currentspd = movespeed * Time.deltaTime * (1);

        transform.Translate(horizontalInput * currentspd, 0, 0);


        if (Input.GetKey("a") | Input.GetKey("left"))
        {


        }

         

        if (Input.GetKeyDown(KeyCode.Space) && grounded){
            jump_current = new Vector3(0.0f, 0.0f, 0.0f);
            jumping = true;

            gravitycurrent = 0f;
            grounded = false;
        }

        if (jumping == true)
        {
            if (jump_current.y < jumpforce)
            {
                    jump_current.y += 0.05f;
            }
            else
            {
                jumping = false;
            }
            
            transform.Translate(jump_current);
        }

        if ((grounded == false) && (jumping == false))
        {
            if (gravitycurrent < gravityforce)
            {
                gravitycurrent += 0.001f;

            }
            transform.Translate(0.00f,-gravitycurrent, 0.00f);
            
        }

        

    }




    void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }

    private void OnTriggerEnter(Collider other)
    {
     


        if (transform.position.y > other.gameObject.transform.position.y)
        {

            grounded = true;
            transform.Translate(0.00f, 0.5f, 0.00f);
            standingonground = other.gameObject;

            //BoxCollider Boxbounding = (BoxCollider)other;

        }
    }
    
}
