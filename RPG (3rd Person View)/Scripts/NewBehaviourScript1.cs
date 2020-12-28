using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    // Start is called before the first frame update
    // public Transform[] target;
    // public float speed;
    // private int current;
    public float speed;
    public CharacterController controller;
    private Vector3 position;

    // public AnimationClip run;
    // public AnimationClip idle;
    //public Animation anim;
    void Update()
    {
       // if (transform.position != target[current].position)
      //  {
       //     Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
       //     GetComponent<Rigidbody>().MovePosition(pos);
       // }
       // else current = (current+1)% target.Length;
       if(Input.GetMouseButton(0))
        {
            locatePosition();
        }
        moveToPosition();


    }
    void locatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out hit,1000))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z); 
        }
        
    }
    void moveToPosition()
    {
        if (Vector3.Distance(transform.position, position)> 1)
                {

                   Quaternion newRotation = Quaternion.LookRotation(position-transform.position, Vector3.forward);
                   newRotation.x = 0f;
                   newRotation.z = 0f;
                   transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
                   controller.SimpleMove(transform.forward);
                    //animation.Play(run.name);
               //      anim.SetBool("moving", true);
        }
        else
        {
            //    animation.Play(idle.name);
          //  anim.SetBool("moving", false);
        }

    }
}
