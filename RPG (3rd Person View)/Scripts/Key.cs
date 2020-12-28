using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    public bool pickedUp = false;
    public CollectableManager manager;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pickedUp = true;
            manager.AddToReward();
            gameObject.SetActive(false);
        }
    }
}
