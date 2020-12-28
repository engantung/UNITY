using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    //public GameObject spawnee;
    public Transform Target;
     public int MoveSpeed = 2;
     public int MaxDist = 1000;
     public int MinDist = 3;
    //public GameObject other;
    //public bool stopSpawning = false;
    //public float spawnTime;
    //public float spawnDelay;
    
    // Start is called before the first frame update
    
    void Start()
    {

    }
    
    void Update()
     {
         transform.LookAt(Target);
 
         if (Vector3.Distance(transform.position, Target.position) >= MinDist)
         {
 
             transform.position += transform.forward * MoveSpeed * Time.deltaTime;
 
 
 
             if (Vector3.Distance(transform.position, Target.position) <= MaxDist)
             {
                 //Here Call any function U want Like Shoot at here or something
             }
 
         }
     }
    
}
