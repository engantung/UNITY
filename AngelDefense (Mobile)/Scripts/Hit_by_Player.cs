using System;
using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using UnityEngine;

public class Hit_by_Player : MonoBehaviour
{
 
    public Transform Player;

 
    void Start()
    {
 
    }
    private void OnTriggerEnter(Collider other) {

        if(Player.GetComponent<thirdpersonmovment>().y==true)
        {
 
            Debug.Log("my statue hit by arrow");

       }
       
       else
        {
 
            Debug.Log("my statue hit by katana");
 
        }
       
    }

}
