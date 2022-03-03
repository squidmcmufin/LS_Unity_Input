using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moovingplatform : MonoBehaviour
{
    public Vector3[] Points;
    public int Point_number = 0;
    private Vector3 current_target;

    // tolarance is used to the platform snap cleanly to its final destination.
    // speed is for how quickly it will move between the points.
    // delay_time/delay_start is how long it will wait after stopping at one. vice versa. 
    // automaticwill controle wether it moves autmaticaly between points. 
    public float tolarance;
    public float speed;
    public float delay_time;

    private float delay_start;
    public bool automatic;

    // Start is called before the first frame update
    void Start()
    {
        if (Points.Length > 0)
        {
            current_target = Points[0];
        }
        tolarance = speed = Time.deltaTime;



    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != current_target)
        {
            MovePlatform();


        }

        else
        {
            UpdateTarget();


        }

    }

    void MovePlatform()
    {
        Vector3 heading = current_target - transform.position;

        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        if (heading.magnitude < tolarance)
        {
            transform.position = current_target;
            delay_start = Time.time;
        }
    }

    void UpdateTarget()
    {
        if (automatic)
        {
            if (Time.time - delay_start > delay_time)
            {
                NextPlatform();
            }
        }

    }

    public void NextPlatform()
    {
        Point_number++;
        if (Point_number >= Points.Length)
        {
            Point_number = 0;
        }
        current_target = Points[Point_number];

    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;

    }



}


    //public class platform_triggre_script : MonoBehaviour
    //{
    //    public moving_platform_script Platform;

    //    private void OnTriggerEnter(Collider other)
    //    {
    //        Platform.NextPlatform();
    //    }

      

      //}  







