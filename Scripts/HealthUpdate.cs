using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUpdate : MonoBehaviour
{
    public Image healthBar;
    public float max_health = 100f;
    public float cur_health = 0f;
    public bool alive = true;
    private bool isCoroutineExecuting = false;
    Animation myAnimation;
    public AnimationClip dead;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        cur_health = max_health;
        SetHealthBar();
        myAnimation = GetComponent<Animation>();
    }

    void DoDamage()
    {
        TakeDamage(10f);
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;
    
        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);
    
        // Code to execute after the delay
    
        isCoroutineExecuting = false;
    }

    public void TakeDamage(float amount)
    {
        if(!alive)
        {
 
            return;
        }

        cur_health -= amount;

        if(cur_health <= 0)
        {
            cur_health = 0;
            alive = false;
        }
        
        SetHealthBar();
    } 

    public void SetHealthBar()
    {
        float my_health = cur_health / max_health;
        healthBar.transform.localScale = new Vector3 (Mathf.Clamp(my_health, 0f, 1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);

    }
    // Update is called once per frame
}
