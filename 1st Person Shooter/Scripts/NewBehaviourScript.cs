using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    Transform playerTransform;
    UnityEngine.AI.NavMeshAgent myNavmesh;
    public float checkRate = 0.01f;

    public GameObject EnemyDestroyEffect;

    float nextCheck;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        myNavmesh = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            myNavmesh.transform.LookAt(playerTransform);

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            Instantiate(EnemyDestroyEffect, transform.position, Quaternion.identity);
            Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}
