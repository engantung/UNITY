using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class build : MonoBehaviour
{
    public Zombie zombieDollar;
    public DollarManager manager;
    public int dollarBalance;
    int dollarTaken;
    //public int dollarKillingResult;
    //public int countBlock;   
    [SerializeField]
    Transform CamChild;
    [SerializeField]
    GameObject[] FloorBuild ;
    [SerializeField]
    Transform[] FloorPrefab;

    int x = 0;
    RaycastHit HHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dollarBalance = zombieDollar.dollarBalance;
        
        //if (Input.GetKeyDown(KeyCode.W))
        if (CrossPlatformInputManager.GetButtonDown("W") || Input.GetKey(KeyCode.W))
        {
            

            for (int y = 0; y < FloorBuild.Length; y++)
                FloorBuild[y].SetActive(false);

        
        }
        //else if (Input.GetKeyDown(KeyCode.F1))
        else if (CrossPlatformInputManager.GetButtonDown("F1") || Input.GetKeyDown(KeyCode.F1))
        {
            x = 0;
           
            for(int y=0; y< FloorBuild.Length; y++)
                FloorBuild[y].SetActive(false);

            FloorBuild[x].SetActive(true);
        }
        //else if(Input.GetKeyDown(KeyCode.F2))
        else if(CrossPlatformInputManager.GetButtonDown("F2") || Input.GetKeyDown(KeyCode.F2))
            {
            x = 1;

            for (int y = 0; y < FloorBuild.Length; y++)
                FloorBuild[y].SetActive(false);

            FloorBuild[x].SetActive(true);
        }
        //else if (Input.GetKeyDown(KeyCode.F3))
        else if (CrossPlatformInputManager.GetButtonDown("F3") || Input.GetKeyDown(KeyCode.F3))
        {
            x = 2;

            for (int y = 0; y < FloorBuild.Length; y++)
                FloorBuild[y].SetActive(false);

            FloorBuild[x].SetActive(true);

        }
        //else if (Input.GetKeyDown(KeyCode.F4))
        else if (CrossPlatformInputManager.GetButtonDown("F4") || Input.GetKeyDown(KeyCode.F4))
        {
            x = 3;

            for (int y = 0; y < FloorBuild.Length; y++)
                FloorBuild[y].SetActive(false);

            FloorBuild[x].SetActive(true);

        }

        if (Physics.Raycast(CamChild.position, CamChild.forward, out HHit, 300f))
        {
          //  UnityEngine.Debug.Log("helloooooooooooo      " + HHit.point.y*5 + "                     " + FloorBuild.localScale.y);
          //  UnityEngine.Debug.Log("Mathf.RoundToInt      " + Mathf.RoundToInt(HHit.point.y*5) + "                 " + Mathf.RoundToInt(HHit.point.y / 3));
          //  UnityEngine.Debug.DrawRay(CamChild.position, CamChild.forward * 200, Color.yellow);
            FloorBuild[x].transform.position = new Vector3(Mathf.RoundToInt(HHit.point.x) != 0 ? Mathf.RoundToInt(HHit.point.x / 1) * 1 : 1
                , (Mathf.RoundToInt(HHit.point.y *5) != 0 ? Mathf.RoundToInt(HHit.point.y*5 / 2) * 1 : 0) + FloorBuild[x].transform.localScale.y-1
                , Mathf.RoundToInt(HHit.point.z) != 0 ? Mathf.RoundToInt(HHit.point.z / 3) * 3 : 3);
             FloorBuild[x].transform.eulerAngles = new Vector3(0, Mathf.RoundToInt(transform.eulerAngles.y) !=0 ? Mathf.RoundToInt(transform.eulerAngles.y / 90f) * 90f : 0 , 0);
            //Input.GetMouseButtonDown(0)
            
            
                //if (Input.GetKeyDown(KeyCode.C))
                if (CrossPlatformInputManager.GetButtonDown("C") || Input.GetKeyDown(KeyCode.C)) 
                {
                    if(dollarBalance > 50)
                    {
                        //Quaternion.identity
                        if(FloorBuild[x].active)
                        {
                            Instantiate(FloorPrefab[x], FloorBuild[x].transform.position, FloorBuild[x].transform.rotation);
                            dollarTaken = manager.DollarToBuy(50);
                            //dollar = manager.DollarToBuy(dollar, 50);
                            //dollar = dollar - 50;
                            //countBlock = countBlock + 1;
                        }
                        
                    }
                    else
                    {
                        Debug.Log("Insufficient Fund!! You may not plant block");
                    }
                    dollarBalance = manager.DollarAmount(dollarTaken);
                }
                //zombieDollar.dollarProduced = dollar; 
            
            
        }
        
        //Block.SetActive(true);
    }
}
