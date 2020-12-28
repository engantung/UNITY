using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    // Start is called before the first frame update
    public HealthUpdate ObjectHPStatus;
    private SFXManager sfxPlayer;

    private SFXManager sfxBarrier;
    void Start()
    {
        ObjectHPStatus.alive = false;
        Object.Destroy(gameObject, 120.0f);
        sfxBarrier = FindObjectOfType<SFXManager>();
        sfxPlayer = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ObjectHPStatus.alive = true;
        if(ObjectHPStatus.cur_health <= 0)
        {
            //StatueDead = true;
            //manager.BossStatus(BossDead);
            //myAnimation.CrossFade(dead.name);
            //Destroy(GetComponent<BoxCollider>());
            //Destroy(myNavmesh);
            Object.Destroy(gameObject, 5f);
            //Debug.Log("Zombie attacking the Wall");
            //DamageToObject.TakeDamage(damage01);
            sfxBarrier.barrierCrush.Play();
            sfxPlayer.playerDead.Play();
            //attacking.Play();
            //Debug.Log(Target);
            
            //Player_anim = Player.GetComponent<Animator>();
            //Player_anim.SetBool("death", true);
            FindObjectOfType<ManagingGame>().EndGame();
            //manager.AddToBossPoint();
        }
        
    }
    
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Zombie" || col.gameObject.name == "Zombie(Clone)" )
        {
            Debug.Log("myAngel got hit by Zombie");
        }
        else if(col.gameObject.name == "Elven Long Bow Arrow Variant(Clone)" || col.gameObject.name == "katana" )
        {
            Debug.Log("myAngel got by Player");
        }
    }
    
}
