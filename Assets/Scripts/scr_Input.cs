using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Input : MonoBehaviour
{
    private float movespeed = 4.0f;

    private float Dashmultiplier = 1.5f;

    private Vector3 StartCoords = new Vector3(0.0f,0.0f,0.0f);

    private Vector3 PreviousPosition = new Vector3(0.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        StartCoords = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PreviousPosition = transform.position;


        float horizontalInput = Input.GetAxis("Horizontal") + Input.GetAxis("Horizontal_Keyboard");
        
        float verticalInput = (-Input.GetAxis("Vertical")) + (- Input.GetAxis("Vertical_Keyboard"));

       

        var currentspd = movespeed * Time.deltaTime * (1);

        transform.Translate(horizontalInput * currentspd,  verticalInput * currentspd, 0);
    }

    
}
