﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseOver()
    {
        player.GetComponent<thirdpersonmovment>().opponent = gameObject;
    }
}
