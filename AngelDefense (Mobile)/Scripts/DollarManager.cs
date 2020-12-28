using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DollarManager : MonoBehaviour
{
    int dollarAdded = 0;
    int dollarTaken = 0;
    int dollarBalance = 0;
    //public int dollarFirst = 50;

    public Text countDollar;
    //int dollar = 0;
    // Start is called before the first frame update
    public int AddToDollar(int arrow)
    {
        //dollarAdded = dollarAdded + arrow;
        dollarAdded = arrow;
        //Debug.Log(dollarCount);
        //countCollection.text = "Student's Cards : " + collectionCount.ToString();
        return dollarAdded;
    }

    public int DollarToBuy(int plant)
    {
        //dollarTaken = dollarTaken - plant;
        dollarTaken = plant*(-1);
        //Debug.Log(dollarTaken);
        //countCollection.text = "Student's Cards : " + collectionCount.ToString();
        return dollarTaken;
    }

    public int DollarAmount(int dollar)
    {
        dollarBalance = dollarBalance + dollar;
        countDollar.text = "$ " + dollarBalance.ToString();
        return dollarBalance;

    } 

}
