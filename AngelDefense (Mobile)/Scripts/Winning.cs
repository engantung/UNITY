using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winning : MonoBehaviour
{
    public Animator anim;
   
    GameObject[] enemies;
    public float waitingTime = 120f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    IEnumerator KingdomCome()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(waitingTime);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        
       
        
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("arthur_passive_01"))
        {
            Debug.Log("Destroy All Evils");
            GameObject[] enemies = GameObject. FindGameObjectsWithTag("Enemy");
            for(int i=0; i< enemies. Length; i++)
            {
                Destroy(enemies[i]);
            }
        }
        FindObjectOfType<ManagingGame>().ProceedNextLevel();
        
        
    }
    
    void Update()
    {
        StartCoroutine(KingdomCome());
    }
    
}
