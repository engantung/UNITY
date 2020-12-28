using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource zombieHurt;
    public AudioSource zombieDead;
    public AudioSource zombieAttack;
    public AudioSource zombieRun;

    public AudioSource bossHurt;
    public AudioSource bossDead;
    public AudioSource bossAttack;
    public AudioSource bossRun;

    public AudioSource playerBowAttack;
    public AudioSource playerSwordAttack;
    public AudioSource playerWalk;
    public AudioSource playerDead;
    public AudioSource playerHurt;
    public AudioSource playerStopRun;

    public AudioSource barrierCrush;

    private static bool sfxmanExists;

    // Start is called before the first frame update
    void Start()
    {
        if(!sfxmanExists)
        {
            sfxmanExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
