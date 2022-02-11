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

    public Rigidbody rb;

    public Vector3 jump;
    public float jumpforce = 3f; 


    void Start()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        StartCoords = transform.position;

        jump = new Vector3 (0.0f, 2.0f, 0.0f);



    }

    void Update()
    {
        PreviousPosition = transform.position;


        float horizontalInput = Input.GetAxis("Horizontal") + Input.GetAxis("Horizontal_Keyboard");

        float verticalInput = (-Input.GetAxis("Vertical")) + (-Input.GetAxis("Vertical_Keyboard"));



        var currentspd = movespeed * Time.deltaTime * (1);

        transform.Translate(horizontalInput * currentspd, verticalInput * currentspd, 0);


        if (Input.GetKey("a") | Input.GetKey("left"))
        {


        }

         

        if (Input.GetKeyDown(KeyCode.Space) && grounded){
            rb.AddForce(jump * jumpforce, ForceMode.Impulse);
            grounded = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }



}
