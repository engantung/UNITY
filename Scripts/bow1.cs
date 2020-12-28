using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow1 : MonoBehaviour
{

    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            
               GameObject newBullet = ObjectPool.SharedInstance.GetPooledObject();
            newBullet.transform.position = transform.position +transform.forward;
            newBullet.transform.rotation = transform.rotation ;
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * 5;
            newBullet.SetActive(true);
           // UnityEngine.Debug.Log("rrrrrrrrrrrrrrrrrr" + transform.position);
          //  UnityEngine.Debug.Log("forward red axe" + transform.forward);

        }
    }
}
