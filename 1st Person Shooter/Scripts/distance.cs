using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class distance : MonoBehaviour
{
    public GameObject Top;
    public GameObject Bottom ;
    public GameObject right;
    public GameObject left ;

    private RectTransform reticle;

    int x = (Screen.width / 2);
    int y = (Screen.height / 2);

    Image image1, image2, image3, image4;

    public Color mycolor;
    void Start()
    {
        reticle = GetComponent<RectTransform>();
        image1 = Top.GetComponent<Image>();
        image2 = Bottom.GetComponent<Image>();
        image3 = left.GetComponent<Image>();
        image4 = right.GetComponent<Image>();

    }

    void Update()
    {
        Vector3 pos = new Vector3(x, y, 0);
        Ray ray = Camera.main.ScreenPointToRay(pos);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Debug.Log(Input.mousePosition);
            //Debug.Log(hit.collider.gameObject.name);
            if (hit.distance <= 10)
            {
                
                
                if (hit.collider.gameObject.name == "Cube")
                {
                    reticle.sizeDelta = new Vector2(75, 75);
                    image1.color = Color.green;
                    image2.color = Color.green;
                    image3.color = Color.green;
                    image4.color = Color.green;
                    Debug.Log("Boss has been found");
                }

                /*
                else if (hit.collider.gameObject.name == "GoodGuy")
                {
                    reticle.sizeDelta = new Vector2(75, 75);
                    image1.color = Color.blue;
                    image2.color = Color.blue;
                    image3.color = Color.blue;
                    image4.color = Color.blue;
                    Debug.Log("Don't shoot me, please, I'm a good guy");
                }

                */
                else if (hit.collider.gameObject.name == "Cube(Clone)")
                {
                    reticle.sizeDelta = new Vector2(75, 75);
                    image1.color = mycolor;
                    image2.color = mycolor;
                    image3.color = mycolor;
                    image4.color = mycolor;
                    Debug.Log("Targetting to the Enemy");
                }

                else
                {
                    reticle.sizeDelta = new Vector2(75, 75);
                    image1.color = Color.black;
                    image2.color = Color.black;
                    image3.color = Color.black;
                    image4.color = Color.black;
                }

            }

            else
            {
                
                
                if (hit.collider.gameObject.name == "Cube")
                {
                    reticle.sizeDelta = new Vector2(25, 25);
                    image1.color = Color.green;
                    image2.color = Color.green;
                    image3.color = Color.green;
                    image4.color = Color.green;
                    Debug.Log("Boss has been found");
                }
                
                else if (hit.collider.gameObject.name == "Cube(Clone)")
                {
                    reticle.sizeDelta = new Vector2(25, 25);
                    image1.color = mycolor;
                    image2.color = mycolor;
                    image3.color = mycolor;
                    image4.color = mycolor;
                    Debug.Log("Targetting to the Enemy");
                }

                else
                {
                    reticle.sizeDelta = new Vector2(25, 25);
                    image1.color = Color.black;
                    image2.color = Color.black;
                    image3.color = Color.black;
                    image4.color = Color.black;
                }
            }
            
            // Instantiate(yourCubePrefab, hit.point, Quaternion.LookRotation(hit.normal));
        }

    }
}
