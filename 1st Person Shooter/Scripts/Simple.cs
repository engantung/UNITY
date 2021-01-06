using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple : MonoBehaviour
{
    public float count =0;
    public GameObject  redCube;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(" hello world i am  ");
    }

    // Update is called once per frame
    void Update()
    {
        count += 0.1f;
        //  Debug.Log(count);
         redCube.transform.position = new Vector3(Mathf.Sin(count),Mathf.Cos(count),0);
    }
}
