using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Input : MonoBehaviour
{
    private float movespeed = 4.0f;

    private float Dashmultiplier = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {
         
        float horizontalInput = Input.GetAxis("Horizontal");
        
        float verticalInput = -Input.GetAxis("Vertical");

        float Dash = Input.GetAxis("Dash");

        var currentspd = movespeed * Time.deltaTime * (1+(Dash* Dashmultiplier));

        transform.Translate(horizontalInput * currentspd,  verticalInput * currentspd, 0);
    }
}
