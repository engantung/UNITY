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

    public Animator anime;

    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;


        if (!inRange())
        {
            chase();
        }
        else
        {
            
            anime.SetBool("moving", false);
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
