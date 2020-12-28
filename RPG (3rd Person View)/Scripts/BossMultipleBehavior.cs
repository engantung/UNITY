using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMultipleBehavior : MonoBehaviour
{
    public HealthUpdate DamageToObject;
    public HealthUpdate ObjectHPStatus;
    public bool BossDead = false;
    private Coroutine pulseOnGroundRoutine;
    public CollectableManager manager;   

// Start is called before the first frame update
    Transform playerTransform;
    private float dist;
    public float moveSpeed;
    public float howclose;
    public float howclosetoattack;
    UnityEngine.AI.NavMeshAgent myNavmesh;
    public float checkRate = 0.01f;
    private float animSpeed = 1.25f;
    
    public float damage01 = 0.5f;
    public float damage02 = 0.2f;
    public float damageNIL = -0.1f;

    public AnimationClip walk;
    public AnimationClip wait;
    public enum BossFight{AttackType01 = 0, AttackType02 = 1, Block01 = 2, Block02 = 3, Dodge01 = 4, Dodge02 = 5};
    
    public AnimationClip attack1;
    public AnimationClip attack2;
    public AnimationClip block1;
    public AnimationClip block2;
    public AnimationClip dodge1;
    public AnimationClip dodge2;

    public AnimationClip dead;

    public BossFight currentStyle;
    private bool isCoroutineExecuting = false;

    Animation myAnimation;

    //public GameObject EnemyDestroyEffect;

    float nextCheck;
    void Start()
    {
        pulseOnGroundRoutine = StartCoroutine(PulseOnGround());
        ObjectHPStatus.alive = false;
        myAnimation = GetComponent<Animation>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        myNavmesh = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        ObjectHPStatus.alive = true;
        dist = Vector3.Distance(playerTransform.position, transform.position);
        if(ObjectHPStatus.cur_health > 0)
        {
            if (Time.time > nextCheck && dist <= howclose && dist >= howclosetoattack)
            {
                nextCheck = Time.time + checkRate;
                myNavmesh.transform.LookAt(playerTransform);
                myAnimation.clip = walk;
                myAnimation.Play();
                GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
                transform.position += transform.forward * moveSpeed * Time.deltaTime; 
            }
        
            else if (Time.time > nextCheck && dist < howclosetoattack)
            {
                Random_Attack();
                Debug.Log(currentStyle);
                GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed); 
            }
            else
            {
                myAnimation.clip = wait;
                myAnimation.Play();
            }
        }
        else if(ObjectHPStatus.cur_health <= 0)
        {
            BossDead = true;
            manager.BossStatus(BossDead);
            myAnimation.CrossFade(dead.name);
            Destroy(GetComponent<BoxCollider>());
            Destroy(myNavmesh);
            Destroy(gameObject, 2.55f);
            //manager.AddToBossPoint();
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;
    
        isCoroutineExecuting = true;
    
        yield return new WaitForSeconds(time);
    
        // Code to execute after the delay
    
        isCoroutineExecuting = false;
    }
    
    //OtherGameObject.cur_health = 0;
    public void Random_Attack()
     {

            currentStyle = (BossFight)Random.Range(0, System.Enum.GetValues(typeof(BossFight)).Length);
            //Add attacking stuff here
            if (currentStyle == BossFight.AttackType01)
            {
                nextCheck = Time.time + checkRate;
                myNavmesh.transform.LookAt(playerTransform);
                myAnimation[attack1.name].speed = animSpeed;
                myAnimation.CrossFade(attack1.name);
                DamageToObject.TakeDamage(damage01);
                currentStyle = (BossFight)Random.Range(0, System.Enum.GetValues(typeof(BossFight)).Length);                                                                                               //make it random currentAttack
                if (currentStyle == BossFight.AttackType02)
                {
                    nextCheck = Time.time + checkRate;
                    myNavmesh.transform.LookAt(playerTransform);
                    myAnimation[attack2.name].speed = animSpeed;
                    myAnimation.CrossFade(attack2.name);
                    DamageToObject.TakeDamage(damage02);
                    currentStyle = (BossFight)Random.Range(0, System.Enum.GetValues(typeof(BossFight)).Length); // make it random currentAttack 
                    if (currentStyle == BossFight.Block01)
                    {
                        nextCheck = Time.time + checkRate;
                        myNavmesh.transform.LookAt(playerTransform);
                        myAnimation[block1.name].speed = animSpeed;
                        myAnimation.CrossFade(block1.name);
                        ObjectHPStatus.TakeDamage(damageNIL);
                        currentStyle = (BossFight)Random.Range(0, System.Enum.GetValues(typeof(BossFight)).Length); // make it random currentAttack
                        if (currentStyle == BossFight.Block02)
                        {
                            nextCheck = Time.time + checkRate;
                            myNavmesh.transform.LookAt(playerTransform);
                            myAnimation[block2.name].speed = animSpeed;
                            myAnimation.CrossFade(block2.name);
                            ObjectHPStatus.TakeDamage(damageNIL);
                            currentStyle = (BossFight)Random.Range(0, System.Enum.GetValues(typeof(BossFight)).Length); // make it random currentAttack
                            if (currentStyle == BossFight.Dodge01)
                            {
                                nextCheck = Time.time + checkRate;
                                myNavmesh.transform.LookAt(playerTransform);
                                myAnimation[dodge1.name].speed = animSpeed;
                                myAnimation.CrossFade(dodge1.name);
                                ObjectHPStatus.TakeDamage(damageNIL);
                                currentStyle = (BossFight)Random.Range(0, System.Enum.GetValues(typeof(BossFight)).Length); // make it random currentAttack
                                if (currentStyle == BossFight.Dodge02)
                                {
                                    nextCheck = Time.time + checkRate;
                                    myNavmesh.transform.LookAt(playerTransform);
                                    myAnimation[dodge2.name].speed = animSpeed;
                                    myAnimation.CrossFade(dodge2.name);
                                    currentStyle = (BossFight)Random.Range(0, System.Enum.GetValues(typeof(BossFight)).Length); // make it random currentAttack
                                }

                            }

                        }

                    }    
                }
            }
     }

     
    public IEnumerator PulseOnGround()
    {
        while (gameObject != null && gameObject.activeInHierarchy)
        {
            Debug.Log("BOSS GOBLIN is a LIVE");
            yield return new WaitForFixedUpdate();
        }
    }
    
    public void OnDestroy()    
    {
        StopCoroutine(pulseOnGroundRoutine);
    }
}
