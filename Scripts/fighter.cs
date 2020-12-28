using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class fighter : MonoBehaviour
{
    // Start is called before the first frame update

    // public GameObject opponent;
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  UnityEngine.Debug.Log(opponent);
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButton(1))
        { player.GetComponent<thirdpersonmovment>().opponent = gameObject; }
    }
}
