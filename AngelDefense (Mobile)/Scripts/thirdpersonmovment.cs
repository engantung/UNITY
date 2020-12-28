using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class thirdpersonmovment : MonoBehaviour
{

    //public CharacterController controller;
    //public ManagingGame gameManager;
    public Joystick joystick;
    [SerializeField] GameObject[] buttons;

    public HealthUpdate ObjectHPStatus;
    public float speed = 2.0f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    
    public Transform[] target;
    public float speed2;
    private int current;
    public GameObject shield;
    public GameObject shield2;
    public GameObject katana;
    public GameObject katana2;
    public GameObject bow;
    public GameObject bow2;

    Collider  m_Collider;


    public GameObject arrow;
    public GameObject cross;
    // Shield sh = gameObject.Find("Shield").GetComponent<Shield>();
    public GameObject play;

    bool x = true;
    public bool y = true;
    string locationk = "B-palm_01_LL";

    string locationlefthand = "B-palm_01_LL";

    string locationb = "B-headd";
    public float speed3 = 3.0f;
    public CharacterController controller;
    //private Vector3 position;

    //public NewBehaviourScript p;
    public Animator anim;

    RaycastHit hit;
    RaycastHit hit2;
    private float raycastLength = 500;
    public Vector3 posi;
    public Vector3 position;


    /*
    // select  
    public float speed;
    public float range;
    public CharacterController controller;
    
    public Animator anime;

    public Transform player;
    // fighter 
    */
    public GameObject opponent;

    public GameObject dumy;




    Vector3 velocity;
    //public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
   
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    bool isGrounded;

    private SFXManager sfxPlayer;
    
    void Start()
    {
        position = transform.position;
        //ObjectHPStatus.alive = false;
        //   bow.transform.localPosition = new Vector3(0.279f, 0.13f, -0.238f);
        //  bow.transform.localRotation = Quaternion.Euler(184.556f, -344.57f, -52.50198f);
        // bow.transform.localPosition = new Vector3(0.279f, 0.13f, -0.238f);
        //bow.transform.localRotation = Quaternion.Euler(184.556f, -344.57f, -52.50198f);
        //katana.transform.localPosition = new Vector3(-0.009f, 0.114f, 0.056f);
        //katana.transform.localRotation = Quaternion.Euler(-169.114f, 6.857986f, 19.489f);




      //  bow.transform.localPosition = new Vector3(-0.103f, 0.052f, 0.072f);
      //  bow.transform.localRotation = Quaternion.Euler(184.556f, -344.57f, -52.50198f);

       // bow.transform.localPosition = new Vector3(0.113f, -0.012f, 0.641f);
       // bow.transform.localRotation = Quaternion.Euler(180.31f, -343.384f, -49.327f);
        bow.transform.localPosition = new Vector3(-0.052f, -0.031f, 0.044f);
        bow.transform.localRotation = Quaternion.Euler(174.565f, -356.943f, -113.556f);


        katana.transform.localPosition = new Vector3(-0.223f, 0.338f, -0.155f);
        katana.transform.localRotation = Quaternion.Euler(-170.524f, 5.503998f, -58.02698f);
        m_Collider = katana.GetComponent<Collider>();
        sfxPlayer = FindObjectOfType<SFXManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        ObjectHPStatus.alive = true;
        if(ObjectHPStatus.cur_health > 0)
        {
            dumy.transform.localPosition = new Vector3(0, -1, 0);
            dumy.transform.localRotation = Quaternion.Euler(0, 0, 0);

            Physics.Raycast(transform.position, transform.forward, out hit2, raycastLength);



            UnityEngine.Debug.DrawRay(transform.position, transform.forward * raycastLength, Color.yellow);



            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Input.GetKeyDown(KeyCode.W)
            if (Input.GetMouseButton(1))
            {

                if (Physics.Raycast(ray, out hit, raycastLength))
                {
                    posi = hit.point;

                    position = new Vector3(hit.point.x, hit.point.y, hit.point.z);

                }

            }
            //UnityEngine.Debug.Log("positionnnnnnnnnnnn"+position);
            UnityEngine.Debug.DrawRay(ray.origin, ray.direction * raycastLength, Color.yellow);

            //  p = GameObject.FindObjectOfType<NewBehaviourScript>();
            
            //float horizontal = Input.GetAxis("Horizontal");
            float horizontal = joystick.Horizontal;
            //float vertical = Input.GetAxis("Vertical");
            float vertical = joystick.Vertical;

            //UnityEngine.Debug.Log("horizontal" + horizontal);
            // UnityEngine.Debug.Log("vertical" + vertical);
            // UnityEngine.Debug.Log("horizontal" + p.posi.x);
            //float x = ((p.posi.x - (-49)) / (49 - (-49)));
            // UnityEngine.Debug.Log("vertical" + p.posi.z);
            // float y = ((p.posi.z - (-62)) / (36 - (-62)));
            // UnityEngine.Debug.Log("xxxxxx       " + x);
            // UnityEngine.Debug.Log("zzzzzzzz     " + y);
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            // UnityEngine.Debug.Log("atackingggggggggg" + shield.transform.localRotation);
            // UnityEngine.Debug.Log("hhhhhhhhhhhhhh" + shield.transform.localPosition);
            // UnityEngine.Debug.Log("22222222hhhhhh" + shield2.transform.position);
            if (x == true)
            {
                katana2.transform.position = GameObject.Find(locationb).transform.position;
                katana2.transform.rotation = GameObject.Find(locationb).transform.rotation;

                bow2.transform.position = GameObject.Find(locationk).transform.position;
                bow2.transform.rotation = GameObject.Find(locationk).transform.rotation;

            }
            else
            {
                //  katana2.transform.position = GameObject.Find(locationk).transform.position;
                //  katana2.transform.rotation = GameObject.Find(locationk).transform.rotation;
                //  bow2.transform.position = GameObject.Find(locationb).transform.position;
                //   bow2.transform.rotation = GameObject.Find(locationb).transform.rotation;
                // bow.transform.localPosition = new Vector3(-0.114f, 0.014f, 0.077f);
                //  bow.transform.localRotation = Quaternion.Euler(184.556f, -344.57f, -52.50198f);
                katana2.transform.position = GameObject.Find(locationb).transform.position;
                katana2.transform.rotation = GameObject.Find(locationb).transform.rotation;

                bow2.transform.position = GameObject.Find(locationk).transform.position;
                bow2.transform.rotation = GameObject.Find(locationk).transform.rotation;

            }


            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;

            }

            velocity.y += gravity * 1.8f * Time.deltaTime;
            // Debug.Log( velocity.y );
            controller.Move(velocity * Time.deltaTime);
            // UnityEngine.Debug.Log(isGrounded);
            if (Input.GetButtonDown("Jump") && isGrounded)
            //if ((CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded) || (Input.GetButtonDown("Jump") && isGrounded))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }


            //&& Input.GetMouseButton(0)
            //Vector3.Distance(transform.position, position) > 2
            if (direction.magnitude > 0.1f)
            {
                

                //UnityEngine.Debug.Log("Distance     " + Vector3.Distance(transform.position, position));
                //UnityEngine.Debug.Log("transform position     " + transform.position);
                //  UnityEngine.Debug.Log("position     " + position);

                /*

                Quaternion newRotation = Quaternion.LookRotation(position - transform.position, Vector3.forward);
                    newRotation.x = 0f;
                    newRotation.z = 0f;
                    transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
                    anim.SetBool("moving", true);
                    controller.SimpleMove(transform.forward* speed3);
                */
                // + cam.eulerAngles.y;
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                anim.SetBool("moving", true);
                controller.Move(direction * speed3 * Time.deltaTime);
                
                /*  transform.LookAt(position);
                controller.SimpleMove(transform.forward * 5);
                anim.SetBool("moving", true);*/


                // direction.magnitude > 0.1f
                //transform.position != p.posi
                //
                // UnityEngine.Debug.Log("xxxxxxxxx               " + p.posi);
                //UnityEngine.Debug.Log("yyyyyyyyyyyyy     " + p.posi.z);
                //UnityEngine.Debug.Log("xx" + direction.x);
                // UnityEngine.Debug.Log("zz" + direction.z);
                //float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                // UnityEngine.Debug.Log("x"+p.posi.x);
                // UnityEngine.Debug.Log("z"+p.posi.z);
                //UnityEngine.Debug.Log("targetAngle        "+targetAngle);
                //  angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                // UnityEngine.Debug.Log("angle      "+angle);
                //  transform.rotation = Quaternion.Euler(0f, angle , 0f);
                // UnityEngine.Debug.Log("transform.rotation"+transform.rotation);
                //  Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                // UnityEngine.Debug.Log("moveDir"+moveDir);

                //  controller.Move(moveDir.normalized * speed * Time.deltaTime);
                //UnityEngine.Debug.Log("moveDir.normalized * speed * Time.deltaTime" +moveDir.normalized * speed * Time.deltaTime);
                // UnityEngine.Debug.Log("moveDir.normalized"+moveDir.normalized);
                // Vector3 pos = Vector3.MoveTowards(transform.position, p.posi, speed2 * Time.deltaTime);
                // UnityEngine.Debug.Log(p.posi.x);

                // controller.Move(p.posi * speed * Time.deltaTime);
                //controller.Move(p.posi * speed * Time.deltaTime);
                //GetComponent<Rigidbody>().MovePosition(pos);
            }
            else
            {
                anim.SetBool("moving", false);
                anim.SetBool("attack", false);
                anim.SetBool("sword off and on", false);
                anim.SetBool("attack2", false);
            // anim.SetBool("hit", false);
                anim.SetBool("arrow", false);




            }
            if (CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.LeftShift))
            {
                anim.SetBool("running", true);
                sfxPlayer.playerWalk.Play();
                speed3 = 6f;
            }
            else if (CrossPlatformInputManager.GetButtonDown("C") || Input.GetKeyUp(KeyCode.LeftShift))
            {
                anim.SetBool("running", false);
                sfxPlayer.playerWalk.Stop();
                sfxPlayer.playerStopRun.Play();
                speed3 = 2f;
            }
            // Input.GetMouseButton(1)
            //Input.GetMouseButtonDown(1)
            //if (Input.GetKey(KeyCode.X))
            if (CrossPlatformInputManager.GetButtonDown("X") || Input.GetKey(KeyCode.X))
            {
                //  + new Vector3(0, 1, 0)
                //ExecuteEvents.Execute<IPointerClickHandler> (buttons[0], new PointerEventData (EventSystem.current), ExecuteEvents.pointerClickHandler); 
                //transform.LookAt(new Vector3(position.x, 0.9f, position.z));



                //UnityEngine.Debug.Log("atackingggggggggg" + position);
                // anim.SetBool("attack", true);
                //  UnityEngine.Debug.Log("atackingggggggggg"+ opponent.name);
                //UnityEngine.Debug.Log("atackingggggggggg" + opponent.name);

                if (y == true)
                {
                    m_Collider.enabled = false;
                    // UnityEngine.Debug.Log("Collider.enabled = " + m_Collider.enabled);
                    //opponent.name != null
                    /*
                    if (true)
                    {
                        // && Vector3.Distance(transform.position, opponent.transform.position) <= 6
                        

                        if (opponent.name == "Cube" || opponent.name == "Enemy")
                        {
                            transform.LookAt(opponent.transform.position);
                        }

                        if (Vector3.Distance(transform.position, opponent.transform.position) > 6)
                        {

                            //  transform.LookAt(opponent.transform.position);
                            //   controller.SimpleMove(transform.forward * 2);
                            //   anim.SetBool("moving", true);
                            //  transform.LookAt(opponent.transform.position);

                            Quaternion rRotation = Quaternion.LookRotation(opponent.transform.position - transform.position, Vector3.forward);
                            rRotation.x = 0f;
                            rRotation.z = 0f;
                            transform.rotation = Quaternion.Slerp(transform.rotation, rRotation, Time.deltaTime * 10);
                            //UnityEngine.Debug.Log("atackingggggggggg");
                            controller.SimpleMove(transform.forward * 2);
                            anim.SetBool("moving", true);

                        }
                        else
                        {


                            anim.SetBool("arrow", true);
                            GameObject newBullet = ObjectPool.SharedInstance.GetPooledObject();
                            newBullet.transform.position = transform.position + transform.forward;
                            newBullet.transform.rotation = transform.rotation;
                            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * 3;
                            //UnityEngine.Debug.Log("rrrrrrrrrrrrrrrrrr" + transform.position);
                            newBullet.SetActive(true);
                        }
                    }*/
                    
            
                            anim.SetBool("arrow", true);
                            
                            GameObject newBullet = ObjectPool.SharedInstance.GetPooledObject();
                            newBullet.transform.position = transform.position + transform.forward;
                            newBullet.transform.rotation = transform.rotation;
                            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * 4;
                            //UnityEngine.Debug.Log("rrrrrrrrrrrrrrrrrr" + transform.position);
                            newBullet.SetActive(true);
                            sfxPlayer.playerBowAttack.Play();
                        
                    

                }
                else
                {
                    m_Collider.enabled = true;
                // UnityEngine.Debug.Log("Collider.enabled = " + m_Collider.enabled);
                    /*
                    if (opponent.name == "Cube" || opponent.name == "Enemy")
                    {
                        if (Vector3.Distance(transform.position, opponent.transform.position) > 2)
                        {

                            //transform.LookAt(opponent.transform.position);
                            Quaternion rRotation = Quaternion.LookRotation(opponent.transform.position - transform.position, Vector3.forward);
                            rRotation.x = 0f;
                            rRotation.z = 0f;
                            transform.rotation = Quaternion.Slerp(transform.rotation, rRotation, Time.deltaTime * 10);
                            //UnityEngine.Debug.Log("atackingggggggggg");
                            controller.SimpleMove(transform.forward * 2);
                            anim.SetBool("moving", true);

                        }
                        else
                        {

                            
                            anim.SetBool("attack2", true);
                            anim.SetBool("attack", true);
                        }
                    }
                    */
                    
                    anim.SetBool("attack2", true);
                    anim.SetBool("attack", true);
                    sfxPlayer.playerSwordAttack.Play();
                    
                    

                }


                //UnityEngine.Debug.Log("opponent " + opponent.name);



            }
            else if (Input.GetMouseButton(2))
            {

                // play = GameObject.Find("B-palm_01_R");
                // sh.transform = play.transform;
                // UnityEngine.Debug.Log("atackingggggggggg");




                //  UnityEngine.Debug.Log("atackingggggggggg");
            }
            //Input.GetKeyDown(KeyCode.Keypad0)
            //if (Input.GetKeyDown(KeyCode.V))
            if (CrossPlatformInputManager.GetButtonDown("V") || Input.GetKeyDown(KeyCode.V))
            {
                //UnityEngine.Debug.Log("goooooooooood");
                //anim.SetBool("sword off and on", true);

                

                if (x == true)
                {
                    
                    //locationk = "B-palm_01_RR";
                    locationb = "B-headd";
                // locationlefthand = "B-palm_01_LL";
                    locationk = "B-palm_01_LL";
                    x = false;
                    y = true;
                    cross.SetActive(true);
                    // shield.transform.localPosition = new Vector3(0.476f, -0.068f, -0.151f);
                    // shield.transform.localRotation = Quaternion.Euler(167, -1, -89);
                    //  katana.transform.localPosition = new Vector3(-0.009f, 0.082f, 0.037f);
                    // katana.transform.localRotation = Quaternion.Euler(-157.785f, 81.447f, -4.505005f);

                    //  UnityEngine.Debug.Log("atackingggggggggg" + x+y);
                    //  bow.transform.localPosition = new Vector3(-0.103f, 0.052f, 0.072f);
                    //  bow.transform.localRotation = Quaternion.Euler(184.556f, -344.57f, -52.50198f);
                    bow.transform.localPosition = new Vector3(-0.052f, -0.031f, 0.044f);
                    bow.transform.localRotation = Quaternion.Euler(174.565f, -356.943f, -113.556f);
                    katana.transform.localPosition = new Vector3(-0.223f, 0.338f, -0.155f);
                    katana.transform.localRotation = Quaternion.Euler(-170.524f, 5.503998f, -58.02698f);
                //    bow.transform.localPosition = new Vector3(0.113f, -0.012f, 0.641f);
                //   bow.transform.localRotation = Quaternion.Euler(180.31f, -343.384f, -49.327f);
                }
                else
                {
                    anim.SetBool("sword off and on", true);
                    // location = "B-palm_01_RR";
                    cross.SetActive(false);
                    x = true;
                    y = false;
                    locationb = "B-palm_01_RR";
                    //locationb = "B-palm_01_LL";
                    locationk = "B-headd";
                bow.transform.localPosition = new Vector3(0.251f, -0.036f, -0.295f);
                    bow.transform.localRotation = Quaternion.Euler(363.317f, -175.845f, -56.705f);
                    katana.transform.localPosition = new Vector3(-0.034f, 0.116f, 0.038f);
                    katana.transform.localRotation = Quaternion.Euler(-162.853f, 36.916f, 9.518997f);
                    //  bow.transform.localPosition = new Vector3(0.113f, -0.012f, 0.641f);
                    //  bow.transform.localRotation = Quaternion.Euler(180.31f, -343.384f, -49.327f);
                //  bow.transform.localPosition = new Vector3(0.113f, -0.012f, 0.641f);
                //  bow.transform.localRotation = Quaternion.Euler(180.31f, -343.384f, -49.327f);

                }
            
            }


            // UnityEngine.Debug.Log("opponent " + opponent.name);


            //other = gameObject.GetComponent("NewBehaviourScript1");
            //UnityEngine.Debug.Log(p.posi);
            //UnityEngine.Debug.Log('h');
            // if (transform.position != p.posi)
            //  {
            // UnityEngine.Debug.Log("hell");
            // Vector3 pos = Vector3.MoveTowards(transform.position, p.posi, speed2 * Time.deltaTime);
            //UnityEngine.Debug.Log(pos);
            //controller.Move(p.posi * speed * Time.deltaTime);
            // GetComponent<Rigidbody>().MovePosition(pos);
            // }
            // else current = (current+1)% target.Length;
        }

        else if(ObjectHPStatus.cur_health <=0)
        {
            
            ObjectHPStatus.cur_health = 0;
            ObjectHPStatus.alive = false;
            //anim.SetBool("attack", false);
            anim.SetBool("death", true);
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                    //Debug.Log("Zombie attacking the Angel Statue");
                    sfxPlayer.playerDead.Play();
                    //attacking.Play();
                    //Debug.Log(Target);
            }
            else
            {
                    //Debug.Log("Zombie_Idle or Braking");
            }
            Destroy(gameObject, 10f);
            FindObjectOfType<ManagingGame>().EndGame();

            //sfxPlayer.playerDead.Play();
            //Object.Destroy(gameObject, 5f);
            //attacking.Play();
            //ObjectHPStatus.alive = false;
            //StatueDead = true;
            //manager.BossStatus(BossDead);
            //myAnimation.CrossFade(dead.name);
            //Destroy(GetComponent<BoxCollider>());
            //Destroy(myNavmesh);
            //anim.SetBool("moving", true);
            //anim.SetBool("attack", false);
            //Object.Destroy(gameObject, 2.55f);
            //manager.AddToBossPoint();
        }

    }

}

