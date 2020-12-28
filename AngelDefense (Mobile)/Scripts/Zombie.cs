//CodingBackUp-0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    
    public build blockDollar;
    public DollarManager manager;
    //public int countPlant;

    public int dollarBalance;
    int dollarProduced;
    //public int dollarBuildingResult;

    public HealthUpdate DamageToObject;
    public HealthUpdate DamageHit;
    //public HealthUpdate ObjectHPStatus;
    public int countEnemyDead = 0 ;
    public Transform Target;
    public int MoveSpeed = 2;
    public int RunSpeed = 5;
    public int StopSpeed = 0;
     //public int MaxDist = 1000;
     //public int MinDist = 3;
     public float MinDist = 2.2f;
    //public GameObject other;
    //public bool stopSpawning = false;
    //public float spawnTime;
    //public float spawnDelay;
    public AudioSource walking;
    public AudioSource attacking;

    public float damage01 = 0.1f;
    public float damagehit_by_arrow = 10f;
    public float damagehit_by_katana = 20f;

    public Animator anim;
    string currentAction;

    public Transform Player;
    public GameObject Block;
    private Transform blockPosition;

    public float dist;

    private SFXManager sfxZombie;
    private SFXManager sfxBarrier;

    //public Rigidbody rb;

    // Start is called before the first frame update
    
    void Start()
    {
        anim = GetComponent<Animator>();
        walking = GetComponent<AudioSource>();
        attacking = GetComponent<AudioSource>();
        sfxZombie = FindObjectOfType<SFXManager>();
        sfxBarrier = FindObjectOfType<SFXManager>();
    }
    
    void Update()
     {
        dollarBalance = blockDollar.dollarBalance;
        //dollarBalance = blockDollar.dollarTaken;
        DamageHit.alive = true;
        
        if(DamageHit.cur_health > 0)
        {
            transform.LookAt(Target);
            dist = Vector3.Distance(transform.position, Target.position);
            /*
            if (Vector3.Distance(transform.position, Target.position) >= MinDist)
            {
    
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                anim.SetBool("attack", false);
                anim.SetBool("moving", true);
    
                if (Vector3.Distance(transform.position, Target.position) <= MaxDist)
                {
                    anim.SetBool("attack", true);
                    anim.SetBool("moving", false);
                    //Here Call any function U want Like Shoot at here or something
                }
    
            }
            */
            if (dist >= MinDist)
            {
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                
                if(Block == null)
                {
                    anim.SetBool("attack", false);
                    anim.SetBool("moving", true);
                    sfxZombie.zombieRun.Play();
                    
                    if(anim.GetCurrentAnimatorStateInfo(0).IsName("Z_Attack") || anim.GetCurrentAnimatorStateInfo(0).IsName("Z_Idle"))
                    {
                        MoveSpeed = StopSpeed;
                    }
                    else
                    {
                        MoveSpeed = RunSpeed;
                    }
                    
                }
                else
                {
                    anim.SetBool("moving", false);
                    anim.SetBool("attack", true);
                    //sfxZombie.zombieAttack.Play();
                    Destroy(Block.gameObject, 5f);
                    if(anim.GetCurrentAnimatorStateInfo(0).IsName("Z_Attack"))
                    {
                        //Debug.Log("Zombie attacking the Wall");
                        //DamageToObject.TakeDamage(damage01);
                        
                        sfxBarrier.barrierCrush.Play();
                        
                        
                        //attacking.Play();
                        //Debug.Log(Target);
                    }
                    else
                    {
                        //Debug.Log("Zombie_Idle or Braking");
                    }
                    

                }
                //walking.Play();
                
    
            }
            else if (dist < MinDist)
            {
                anim.SetBool("moving", false);
                anim.SetBool("attack", true);
                //sfxZombie.zombieAttack.Play();
                
                if(anim.GetCurrentAnimatorStateInfo(0).IsName("Z_Attack"))
                {
                    //Debug.Log("Zombie attacking the Angel Statue");
                    DamageToObject.TakeDamage(damage01);
                    sfxZombie.zombieAttack.Play();
                    //attacking.Play();
                    //Debug.Log(Target);
                }
                else
                {
                    //Debug.Log("Zombie_Idle or Braking");
                }
                //Debug.Log(anim.GetCurrentAnimatorStateInfo(0));
                //DamageToObject.TakeDamage(damage01);
                //Here Call any function U want Like Shoot at here or something
            }
            /*
            if (MoveSpeed == StopSpeed && Block != null)
            {
                anim.SetBool("moving", false);
                anim.SetBool("attack", true);
                
                if(anim.GetCurrentAnimatorStateInfo(0).IsName("Z_Attack"))
                {
                    Debug.Log("Zombie attacking");
                    //DamageToObject.TakeDamage(damage01);
                    Destroy(Block.gameObject, 5f);
                    //attacking.Play();
                    //Debug.Log(Target);
                }
                else
                {
                    Debug.Log("Zombie_Idle or Braking");
                }
                //Debug.Log(anim.GetCurrentAnimatorStateInfo(0));
                //DamageToObject.TakeDamage(damage01);
                //Here Call any function U want Like Shoot at here or something
            }
            */
            
        }
        else if(DamageHit.cur_health <=0)
        {
            DamageHit.cur_health = 0;
            DamageHit.alive = false;
            anim.SetBool("attack", false);
            anim.SetBool("dead", true);
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("Z_Idle"))
            {
                    //Debug.Log("Zombie attacking the Angel Statue");
                    sfxZombie.zombieDead.Play();
                    //attacking.Play();
                    //Debug.Log(Target);
            }
            else
            {
                    //Debug.Log("Zombie_Idle or Braking");
            }
            Object.Destroy(gameObject,10f);
            //sfxZombie.zombieDead.Play();
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
        
        //Debug.Log(blockPlant.countBlock);
        
    }
    
    
    private void OnTriggerEnter(Collider other) 
    {
        if(Player.GetComponent<thirdpersonmovment>().y==true)
        {
            //Debug.Log("Zombie hit by arrow");
            DamageHit.TakeDamage(damagehit_by_arrow);
            sfxZombie.zombieHurt.Play();
            //countEnemyDead = countEnemyDead + 50;
            dollarProduced = manager.AddToDollar(50);
            //blockDollar.dollar = dollarProduced;
        }
        else
        {
 
            //Debug.Log("Zombie hit by katana");
            DamageHit.TakeDamage(damagehit_by_katana);
            sfxZombie.zombieHurt.Play();
            dollarProduced = manager.AddToDollar(100);
            //countEnemyDead = countEnemyDead + 100;
            //blockDollar.dollar = dollarProduced;
        }
        dollarBalance = manager.DollarAmount(dollarProduced);
       //Debug.Log(countEnemyDead);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "painted_barrier(Clone)")
        {
            Block = GameObject.Find("painted_barrier(Clone)");
            blockPosition = Block.transform;
            transform.LookAt (blockPosition);
            //Debug.Log(Block.name);
            //Debug.Log("Zombie hit the wall");
            MoveSpeed = StopSpeed;
            //transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
        else
        {
            transform.LookAt (Target);
            //MoveSpeed = 2;
        }
    }


}

