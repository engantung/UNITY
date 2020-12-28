using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QUIT : MonoBehaviour
{
    public void doquit()
    {
        Debug.Log("Has Quit Game");
        Application.Quit();

    }
}
