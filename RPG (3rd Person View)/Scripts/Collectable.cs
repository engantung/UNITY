using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    
    public CollectableManager manager;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            manager.AddToCollection();
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
    }

}
