using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Quest : MonoBehaviour
{
    // Start is called before the first frame update
    public HealthUpdate Boss_HPStatus;
    public string askLine;
    public string completedLine;
    public int requiredCollectables;

    public GameObject reward;

    public CollectableManager manager;

    public Text dialogText;

    bool isQuestCompleted = false;
    bool turnedInCubes = false;

    void Start()
    {
        reward.SetActive(false);
    }

    // Update is called once per frame
    
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(turnedInCubes == false)
            {
                //if(manager.RemoveFromCollection(requiredCollectables) && manager.BossStatus(Boss_HPStatus.cur_health <= 0))
                if(manager.BossStatus(Boss_HPStatus.cur_health <= 0))
                {
                    if(manager.RemoveFromCollection(requiredCollectables))
                    {
                        isQuestCompleted = true;   
                    }
                }
            }

            if(isQuestCompleted == true)
            {
                dialogText.text = completedLine;
                
                if(turnedInCubes == false)
                {
                    turnedInCubes = true;
                    reward.SetActive(true);

                }
                
            }
            else
            {
                    dialogText.text = askLine;
            }
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            dialogText.text = "";
        }
    }

}
