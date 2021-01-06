using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject newBullet = ObjectPool.SharedInstance.GetPooledObject();
         //   GameObject newBullet = Instantiate(bullet);
         //  newBullet.transform.position = transform.position;
         //   newBullet.transform.position = transform.position;
          // newBullet.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z+.7f);
          // Debug.Log( newBullet.transform.position );
          newBullet.transform.position = transform.position + transform.up ;
         // Debug.Log( transform.position );
          // Debug.Log( transform.up );
          newBullet.GetComponent<Rigidbody>().velocity = transform.up *100 ;
          newBullet.SetActive(true);
          audioSource.Play();
        }
    }
}
