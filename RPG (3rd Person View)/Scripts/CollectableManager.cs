using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectableManager : MonoBehaviour
{
    int collectionCount = 0;
    int rewardCount = 0;
    //int BossCount = 0;

    //public BossMultipleBehavior Boss;
    public Text countCollection;
    public Text countReward;
    public Text countBoss;

    public bool BossStatus(bool DeadBoss)
    {
        if(DeadBoss == true)
        {
            //BossCount = 0;
            //BossCount = BossCount - 1;
            //countBoss.text = "BOSS : " + BossCount.ToString();
            countBoss.text = "BOSS : KILLED";
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddToReward()
    {
        rewardCount = rewardCount + 1;
        countReward.text = "Reward : " + rewardCount.ToString();
        //countReward.text = "Student's Cards : " + rewardCount.ToString();
    }

    public void AddToCollection()
    {
        collectionCount = collectionCount + 1;
        countCollection.text = "Student's Cards : " + collectionCount.ToString();
    }

    public bool RemoveFromCollection(int amount)
    {
        if(collectionCount >= amount)
        {
            collectionCount = collectionCount - amount;
            countCollection.text = "Student's Cards : " + collectionCount.ToString();
            return true;

        }
        else
        {
            return false;
        }
    }

}
