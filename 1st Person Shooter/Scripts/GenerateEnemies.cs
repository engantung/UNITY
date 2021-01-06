using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    //public GameObject theGood;

    float randX;
    float randZ;

    //float randXgood;
    //float randZgood;

    Vector3 whereToSpawn;
    //Vector3 whereToPut;

    public float spawnRate = 2f;
    float nextSpawn = 0.0f;


    void Start()
    {
        


    }

    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-40f, 0.47f);
            randZ = Random.Range(0.47f, 40f);
            //randXgood = Random.Range(-40f, 0.47f);
            //randZgood = Random.Range(0.47f, 40f);

            whereToSpawn = new Vector3(randX, transform.position.y, randZ);
            //whereToPut = new Vector3(randXgood, 0.3f, randZgood);
            Instantiate(theEnemy, whereToSpawn, Quaternion.identity);
            //Instantiate(theGood, whereToPut, Quaternion.identity);


        }

    }
    

}
