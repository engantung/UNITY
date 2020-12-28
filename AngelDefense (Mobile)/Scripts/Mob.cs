using System;
using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public float speed;
    public float range;
    public CharacterController controller;
    Collider currentCollided;
    public Animator anime;
    public Transform player;
    public ParticleSystem blood;
    public Transform playerrrrrrrrrrrrr;

    //public int x = 100 ;
    //public ParticleSystem ps;
    void Start()
    {
        //ps = blood.GetComponent<ParticleSystem>();
        ParticleSystem ps = blood.GetComponent<ParticleSystem>();
        var coll = ps.emission;
        coll.enabled = false;
    }
    private void OnTriggerEnter(Collider other) {
        /*
            x = x -10;
            if (x == 0)
            {
                anime.SetBool("death", true);
            }
        */
        if(playerrrrrrrrrrrrr.GetComponent<thirdpersonmovment>().y==true)
        {
            ParticleSystem ps = blood.GetComponent<ParticleSystem>();
            var coll = ps.emission;
            coll.enabled = true;
            anime.SetBool("hit", true);
            //Debug.Log("enemy hit by arrow");
            // UnityEngine.Debug.Log("Collider.enabled = before 1 second from the hit");
            StartCoroutine(ExecuteAfterTime(1f));
       }
       
       else
        {
            ParticleSystem ps = blood.GetComponent<ParticleSystem>();
            var coll = ps.emission;
            coll.enabled = true;
            anime.SetBool("hit", true);
            //Debug.Log("enemy hit by katana");
            // UnityEngine.Debug.Log("Collider.enabled = before 1 second from the hit");
            StartCoroutine(ExecuteAfterTime(1f));
       }
       
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        playerrrrrrrrrrrrr.GetComponent<thirdpersonmovment>().opponent = gameObject;
        ParticleSystem ps = blood.GetComponent<ParticleSystem>();
        //, ParticleSystem ps
        yield return new WaitForSeconds(time);
        //UnityEngine.Debug.Log("Collider.enabled after 1 second from the hit  "+ gameObject.name);
        anime.SetBool("hit", false);
        var coll = ps.emission;
        coll.enabled = false;
            // ps.emission.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        
        if (inRange())
        {
            //  chase();
           
        }
        else
        {
           // anime.SetBool("hit", false);
           // anime.SetBool("moving", false);
        }
        
    }
    bool inRange()
    {
        if(Vector3.Distance(transform.position, player.position)<range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void chase()
    {
        transform.LookAt(player.position);
        controller.SimpleMove(transform.forward * speed);
        anime.SetBool("moving", true);
        


    }
    void OnMouseOver()
    {
        player.GetComponent<thirdpersonmovment>().opponent = gameObject;
    }
}
