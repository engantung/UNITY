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

public class thirdpersonmovment : MonoBehaviour
{
   
   //public CharacterController controller;
   public HealthUpdate BossGameObject;
   public HealthUpdate EnemyGameObject;

   //public BossMultipleBehavior BossBehavior;
   //public EnemyMultipleAttack EnemyBehavior;

   public float speed = 2.0f;
   public float turnSmoothTime = 0.1f;
   float turnSmoothVelocity;
   public Transform cam;

     public Transform[] target;
     public float speed2;
     private int current;
     public float attack_damage1 = 0.3f;
     public float attack_damage2 = 0.1f;
    public GameObject shield;
    public GameObject shield2;
    public GameObject katana;
    public GameObject katana2;
    public GameObject bow;
    public GameObject bow2;


    public GameObject arrow;
    public GameObject cross;
    // Shield sh = gameObject.Find("Shield").GetComponent<Shield>();
    public GameObject  play;

    bool  x = true;
    bool y =true;
    string locationk = "B-palm_01_RR";
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

    void Start()
    {
        position = transform.position;
        //   bow.transform.localPosition = new Vector3(0.279f, 0.13f, -0.238f);
        //  bow.transform.localRotation = Quaternion.Euler(184.556f, -344.57f, -52.50198f);
         

        // bow.transform.localPosition = new Vector3(0.279f, 0.13f, -0.238f);
        //bow.transform.localRotation = Quaternion.Euler(184.556f, -344.57f, -52.50198f);
        //katana.transform.localPosition = new Vector3(-0.009f, 0.114f, 0.056f);
        //katana.transform.localRotation = Quaternion.Euler(-169.114f, 6.857986f, 19.489f);
        bow.transform.localPosition = new Vector3(-0.103f, 0.052f, 0.072f);
        bow.transform.localRotation = Quaternion.Euler(184.556f, -344.57f, -52.50198f);
        katana.transform.localPosition = new Vector3(-0.223f, 0.338f, -0.155f);
        katana.transform.localRotation = Quaternion.Euler(-170.524f, 5.503998f, -58.02698f);

    }

    // Update is called once per frame
    void Update()
    {
        dumy.transform.localPosition = new Vector3(0, -1, 0);
        dumy.transform.localRotation = Quaternion.Euler(0, 0, 0);

        Physics.Raycast(transform.position, transform.forward, out hit2, raycastLength);
        
            
        
        UnityEngine.Debug.DrawRay(transform.position, transform.forward * raycastLength, Color.yellow);



        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0))
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
        // float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        //UnityEngine.Debug.Log("horizontal" + horizontal);
        // UnityEngine.Debug.Log("vertical" + vertical);
        // UnityEngine.Debug.Log("horizontal" + p.posi.x);
        //float x = ((p.posi.x - (-49)) / (49 - (-49)));
        // UnityEngine.Debug.Log("vertical" + p.posi.z);
        // float y = ((p.posi.z - (-62)) / (36 - (-62)));
        // UnityEngine.Debug.Log("xxxxxx       " + x);
        // UnityEngine.Debug.Log("zzzzzzzz     " + y);
        // Vector3 direction = new Vector3(p.posi.x, 0f, p.posi.z).normalized;
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




        if (Vector3.Distance(transform.position, position) > 2 && Input.GetMouseButton(0))
        {
            //UnityEngine.Debug.Log("Distance     " + Vector3.Distance(transform.position, position));
            //UnityEngine.Debug.Log("transform position     " + transform.position);
          //  UnityEngine.Debug.Log("position     " + position);
              Quaternion newRotation = Quaternion.LookRotation(position - transform.position, Vector3.forward);
                newRotation.x = 0f;
                newRotation.z = 0f;
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
                anim.SetBool("moving", true);
                controller.SimpleMove(transform.forward* speed3);

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
            // anim.SetBool("sword off and on", false);
            anim.SetBool("attack2", false);
           




        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("running", true);
            speed3 = 5f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("running", false);
            speed3 = 2f;
        }
        if (Input.GetMouseButton(1))
        {
            // anim.SetBool("attack", true);
           //  UnityEngine.Debug.Log("atackingggggggggg"+ opponent.name);
            if(y== true)
            {
                
                if (opponent.name == "BOSS_GOBLIN")
                {
                    if (opponent.name == "BOSS_GOBLIN" && Vector3.Distance(transform.position, opponent.transform.position) <= 6)
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
                        UnityEngine.Debug.Log("atackingggggggggg");
                        controller.SimpleMove(transform.forward * 2);
                        anim.SetBool("moving", true);
                       
                    }
                    else
                    {

                        
                        anim.SetBool("attack2", true);
                        GameObject newBullet = ObjectPool.SharedInstance.GetPooledObject();
                        newBullet.transform.position = transform.position + transform.forward;
                        newBullet.transform.rotation = transform.rotation;
                        newBullet.GetComponent<Rigidbody>().velocity = transform.forward * 2;
                        UnityEngine.Debug.Log("rrrrrrrrrrrrrrrrrr" + transform.position);
                        newBullet.SetActive(true);
                        //EnemyGameObject.TakeDamage(attack_damage1);
                        BossGameObject.TakeDamage(attack_damage2);
                    }
                }

                else if (opponent.name == "ENEMY_GOBLIN")
                {
                    if (opponent.name == "ENEMY_GOBLIN" && Vector3.Distance(transform.position, opponent.transform.position) <= 6)
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
                        UnityEngine.Debug.Log("atackingggggggggg");
                        controller.SimpleMove(transform.forward * 2);
                        anim.SetBool("moving", true);
                       
                    }
                    else
                    {

                        
                        anim.SetBool("attack2", true);
                        GameObject newBullet = ObjectPool.SharedInstance.GetPooledObject();
                        newBullet.transform.position = transform.position + transform.forward;
                        newBullet.transform.rotation = transform.rotation;
                        newBullet.GetComponent<Rigidbody>().velocity = transform.forward * 2;
                        UnityEngine.Debug.Log("rrrrrrrrrrrrrrrrrr" + transform.position);
                        newBullet.SetActive(true);
                        EnemyGameObject.TakeDamage(attack_damage1);
                        //BossGameObject.TakeDamage(attack_damage2);
                    }
                }



            }
            else
            {
                
                if (opponent.name == "BOSS_GOBLIN")
                {
                    if (Vector3.Distance(transform.position, opponent.transform.position) > 2 )
                    {

                        //transform.LookAt(opponent.transform.position);
                        Quaternion rRotation = Quaternion.LookRotation(opponent.transform.position - transform.position, Vector3.forward);
                        rRotation.x = 0f;
                        rRotation.z = 0f;
                        transform.rotation = Quaternion.Slerp(transform.rotation, rRotation, Time.deltaTime * 10);
                        UnityEngine.Debug.Log("atackingggggggggg");
                        controller.SimpleMove(transform.forward * 2);
                        anim.SetBool("moving", true);

                    }
                    else
                    {
                        

                        anim.SetBool("attack", true);
                        //EnemyGameObject.TakeDamage(attack_damage1);
                        BossGameObject.TakeDamage(attack_damage2);
                    }


                }

                else if (opponent.name == "ENEMY_GOBLIN")
                {
                    if (Vector3.Distance(transform.position, opponent.transform.position) > 2 )
                    {

                        //transform.LookAt(opponent.transform.position);
                        Quaternion rRotation = Quaternion.LookRotation(opponent.transform.position - transform.position, Vector3.forward);
                        rRotation.x = 0f;
                        rRotation.z = 0f;
                        transform.rotation = Quaternion.Slerp(transform.rotation, rRotation, Time.deltaTime * 10);
                        UnityEngine.Debug.Log("atackingggggggggg");
                        controller.SimpleMove(transform.forward * 2);
                        anim.SetBool("moving", true);

                    }
                    else
                    {
                        

                        anim.SetBool("attack", true);
                        EnemyGameObject.TakeDamage(attack_damage1);
                        //BossGameObject.TakeDamage(attack_damage2);
                    }


                }


            }
            UnityEngine.Debug.Log("opponent " + opponent.name);
            


        }
        else if (Input.GetMouseButton(2))
        {
            
            // play = GameObject.Find("B-palm_01_R");
            // sh.transform = play.transform;
            // UnityEngine.Debug.Log("atackingggggggggg");
           



            //  UnityEngine.Debug.Log("atackingggggggggg");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //UnityEngine.Debug.Log("goooooooooood");
            //anim.SetBool("sword off and on", true);
            


            if (x == true)
            {
                locationk = "B-palm_01_RR";
                locationb = "B-headd";
                x = false;
                y = true;
                cross.SetActive(true);
                // shield.transform.localPosition = new Vector3(0.476f, -0.068f, -0.151f);
                // shield.transform.localRotation = Quaternion.Euler(167, -1, -89);
                //  katana.transform.localPosition = new Vector3(-0.009f, 0.082f, 0.037f);
                // katana.transform.localRotation = Quaternion.Euler(-157.785f, 81.447f, -4.505005f);
                bow.transform.localPosition = new Vector3(-0.103f, 0.052f, 0.072f);
                bow.transform.localRotation = Quaternion.Euler(184.556f, -344.57f, -52.50198f);
                katana.transform.localPosition = new Vector3(-0.223f, 0.338f, -0.155f);
                katana.transform.localRotation = Quaternion.Euler(-170.524f, 5.503998f, -58.02698f);
            }
            else
            {
                // location = "B-palm_01_RR";
                cross.SetActive(false);
                x = true;
                y = false;
                locationb = "B-palm_01_RR";
                locationk = "B-headd";
                bow.transform.localPosition = new Vector3(0.251f, -0.036f, -0.295f);
                bow.transform.localRotation = Quaternion.Euler(363.317f, -175.845f, -56.705f);
                katana.transform.localPosition = new Vector3(-0.034f, 0.116f, 0.038f);
                katana.transform.localRotation = Quaternion.Euler(-162.853f, 36.916f, 9.518997f);


            }
        }


        UnityEngine.Debug.Log("opponent " + opponent.name);


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

}
