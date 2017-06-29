using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour {

    private float life;
    public float maxLife;

    Slider healthBar; 
    public float Life
    {
        get { return life; }
    }
	// Use this for initialization
	void Start () {
        maxLife = maxLife > 0 ? maxLife : 100f;

        life = maxLife;

        foreach(Transform t in transform)
        {
            if (t.name == "ZCanvas")
            {
                healthBar = t.GetComponentInChildren<Slider>();
                if (healthBar == null)
                {
                    Debug.LogError("Zombie Health Bar UI (Slider) not found");
                }
                else
                {
                    Debug.Log("Zombie Health Bar LOADED");
                    healthBar.maxValue = maxLife;
                    healthBar.minValue = 0f;
                    healthBar.value = life;
                }
                    
            }
        }

        
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
	}

    public void GetHitted(float damage)
    {
        life -= damage;

        healthBar.value = life;

        if (life <= 0f)
        {
            healthBar.value = 0;
            Die();
        }
            
    }

    public void Die()
    {
        // Play animation
        // Invoke DestroyObject
        GetComponent<Animator>().SetTrigger("DieTrigger");
        Invoke("DestroyZombie", 3.333f);
    }

    public void DestroyZombie()
    {
        Destroy(transform.gameObject);
    }
}
