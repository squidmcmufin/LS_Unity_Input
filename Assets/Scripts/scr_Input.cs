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

    public float jumptime = 1.0f;
    private float jumptime_current = 0.0f;

    public Rigidbody rb;

    private Vector3 jump;

    private Vector3 jump_current;
    public float jumpforce = 0.5f;
    public float gravityforce = 0.6f;
    private float  gravitycurrent = 0f;
    public GameObject standingonground;
    public float jump_accleration = 0.05f;

   
    //public float thrust = 1.0f;
    

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

            //rb = GetComponent<Rigidbody>();
            //rb.AddForce(0.6f, 0.5f, thrust, ForceMode.Impulse);

            jump_current = new Vector3(0.0f, 0.0f, 0.0f);
            jumping = true;

            gravitycurrent = 0f;
            grounded = false;
        }
       
        if (jumping == true)
        {
            if (jump_current.y < jumpforce)
            {
               jump_current.y += jump_accleration;
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

    //public class Example : MonoBehaviour
    //{
    //    Rigidbody m_Rigidbody;
    //    public float m_Thrust = 20f;

    //    void Start()
    //    {
    //        //Fetch the Rigidbody from the GameObject with this script attached
    //        m_Rigidbody = GetComponent<Rigidbody>();
    //    }

    //    void FixedUpdate()
    //    {
    //        if (Input.GetButton("Jump"))
    //        {
    //            //Apply a force to this Rigidbody in direction of this GameObjects up axis
    //            m_Rigidbody.AddForce(transform.up * m_Thrust);
    //        }
    //    }
    //}

    


   /* void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }*/

    private void OnTriggerEnter(Collider other)
    {
     


        if (transform.position.y > other.gameObject.transform.position.y)
        {

            grounded = true;
            //transform.Translate(0.00f, 0.5f, 0.00f);
            standingonground = other.gameObject;

            //BoxCollider Boxbounding = (BoxCollider)other;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(standingonground == other.gameObject)
        {

            grounded = false;    

        }
        
        
    }

}
//public class PhysicsObject : MonoBehaviour
//{

//    public float minGroundNormalY = .65f;
//    public float gravityModifier = 1f;

//    protected Vector3 targetVelocity;
//    protected bool grounded;
//    protected Vector3 groundNormal;
//    protected Rigidbody rb;
//    protected Vector3 velocity;
//    //protected ContactFilter2D contactFilter;
//    protected RaycastHit[] hitBuffer = new RaycastHit[16];
//    protected List<RaycastHit> hitBufferList = new List<RaycastHit>(16);


//    protected const float minMoveDistance = 0.001f;
//    protected const float shellRadius = 0.01f;

//    void OnEnable()
//    {
//        rb = GetComponent<Rigidbody>();
//    }

//    void Start()
//    {
//        //contactFilter.useTriggers = false;
//        //contactFilter.SetLayerMask(Physics.GetLayerCollisionMask(gameObject.layer));
//        //contactFilter.useLayerMask = true;
//    }

//    void Update()
//    {
//        targetVelocity = Vector3.zero;
//        ComputeVelocity();
//    }

//    protected virtual void ComputeVelocity()
//    {

//    }

//    void FixedUpdate()
//    {
//        velocity += gravityModifier * Physics.gravity * Time.deltaTime;
//        velocity.x = targetVelocity.x;

//        grounded = false;

//        Vector3 deltaPosition = velocity * Time.deltaTime;

//        Vector3 moveAlongGround = new Vector3(groundNormal.y, -groundNormal.x);

//        Vector3 move = moveAlongGround * deltaPosition.x;

//        Movement(move, false);

//        move = Vector3.up * deltaPosition.y;

//        Movement(move, true);
//    }

//    void Movement(Vector3 move, bool yMovement)
//    {
//        float distance = move.magnitude;

//        if (distance > minMoveDistance)
//        {
//            int count = rb.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
//            hitBufferList.Clear();
//            for (int i = 0; i < count; i++)
//            {
//                hitBufferList.Add(hitBuffer[i]);
//            }

//            for (int i = 0; i < hitBufferList.Count; i++)
//            {
//                Vector3 currentNormal = hitBufferList[i].normal;
//                if (currentNormal.y > minGroundNormalY)
//                {
//                    grounded = true;
//                    if (yMovement)
//                    {
//                        groundNormal = currentNormal;
//                        currentNormal.x = 0;
//                    }
//                }

//                float projection = Vector3.Dot(velocity, currentNormal);
//                if (projection < 0)
//                {
//                    velocity = velocity - projection * currentNormal;
//                }

//                float modifiedDistance = hitBufferList[i].distance - shellRadius;
//                distance = modifiedDistance < distance ? modifiedDistance : distance;
//            }


//        }

//        rb.position = rb.position + move.normalized * distance;
//    }

//}aa