using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMultipleAttack : MonoBehaviour
{
// Start is called before the first frame update
    public HealthUpdate GameObjectTarget;
    public HealthUpdate ObjectHPStatus;

    private Coroutine pulseOnGroundRoutine;
    Transform playerTransform;
    private float dist;
    public float moveSpeed;
    public float howclose;
    public float howclosetoattack;
    UnityEngine.AI.NavMeshAgent myNavmesh;
    public float checkRate = 0.01f;
    private float animSpeed = 1.25f;
    public float damage01 = 0.05f;
    public float damage02 = 0.10f;
    public float damage03 = 0.20f;
    public AnimationClip walk;
    public AnimationClip wait;
    public enum EnemyAttack{AttackType01 = 0, AttackType02 = 1, AttackType03 = 2};
    public AnimationClip attack1;
    public AnimationClip attack2;
    public AnimationClip attack3;
    public AnimationClip dead;
    
    public EnemyAttack currentAttack;
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
                Debug.Log(currentAttack);
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
            myAnimation.CrossFade(dead.name);
            Destroy(GetComponent<BoxCollider>());
            Destroy(myNavmesh);
            Destroy(gameObject, 2.55f);
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
    
    public void Random_Attack()
     {
         //myAnimation.Play(animateclips[Random.Range(0, Mathf.RoundToInt(animateclips.Length))].name);
         //ExecuteAfterTime(20);
         currentAttack = (EnemyAttack)Random.Range(0, System.Enum.GetValues(typeof(EnemyAttack)).Length);
         //currentAttack = (EnemyAttack)Random.Range(0, 2);
         //ExecuteAfterTime(20);
         //Add attacking stuff here
            
            if (currentAttack == EnemyAttack.AttackType01)
            {
                nextCheck = Time.time + checkRate;
                myNavmesh.transform.LookAt(playerTransform);
                myAnimation[attack1.name].speed = animSpeed;
                myAnimation.CrossFade(attack1.name);
                GameObjectTarget.TakeDamage(damage01);
                currentAttack = (EnemyAttack)Random.Range(0, System.Enum.GetValues(typeof(EnemyAttack)).Length);                                                                                               //make it random currentAttack
                //currentAttack = (EnemyAttack)Random.Range(0, 2);
                //ExecuteAfterTime(100);
                if (currentAttack == EnemyAttack.AttackType02)
                {
                    nextCheck = Time.time + checkRate;
                    myNavmesh.transform.LookAt(playerTransform);
                    myAnimation[attack2.name].speed = animSpeed;
                    myAnimation.CrossFade(attack2.name);
                    GameObjectTarget.TakeDamage(damage02);
                    currentAttack = (EnemyAttack)Random.Range(0, System.Enum.GetValues(typeof(EnemyAttack)).Length); // make it random currentAttack 
                    //currentAttack = (EnemyAttack)Random.Range(0, 2);
                    //ExecuteAfterTime(100);
                    if (currentAttack == EnemyAttack.AttackType03)
                    {
                        nextCheck = Time.time + checkRate;
                        myNavmesh.transform.LookAt(playerTransform);
                        myAnimation[attack3.name].speed = animSpeed;
                        myAnimation.CrossFade(attack3.name);
                        GameObjectTarget.TakeDamage(damage03);
                        currentAttack = (EnemyAttack)Random.Range(0, System.Enum.GetValues(typeof(EnemyAttack)).Length); // make it random currentAttack
                        //currentAttack = (EnemyAttack)Random.Range(0, 2);
                        //ExecuteAfterTime(100);
                    }    
                }
            }
            
     }

    public IEnumerator PulseOnGround()
    {
        while (gameObject != null && gameObject.activeInHierarchy)
        {
            Debug.Log("Enemy GOBLIN is a LIVE");
            yield return new WaitForFixedUpdate();
        }
    }
    
    private void OnDestroy()
    {
        StopCoroutine(pulseOnGroundRoutine);
    }


}
