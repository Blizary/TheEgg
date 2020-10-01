using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpace : MonoBehaviour
{

    [SerializeField] private float maxSize;
    [SerializeField] private float growthAmount;
    [SerializeField] private float growthAmountMax;
    [SerializeField] private float lifeTimer;
    [SerializeField] private float lifeTimerMax;

    [SerializeField] private float deathTimer;
    [SerializeField] private float deathTimerMax;

    [SerializeField] private float innerLifeTimer;
    [SerializeField] private float innerDeathTimer;
    [SerializeField] private float growthAmountInner;
    private float originalSize;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        originalSize = GetComponent<Transform>().localScale.x; //its a circle just need one
        growthAmountInner = Random.Range(growthAmount, growthAmountMax);
        innerLifeTimer = Random.Range(lifeTimer, lifeTimerMax);


    }

    // Update is called once per frame
    void Update()
    {
        LifeCycle();
        DeathTimer();
    }


    void LifeCycle()
    {
      if(innerLifeTimer>=0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(maxSize, maxSize, 1), growthAmount);//growth
            innerLifeTimer -= Time.deltaTime;
        }
      else
        {
            if (!isDead)
            {
                GetComponent<Animator>().SetBool("IsDead", true);
                innerDeathTimer = Random.Range(deathTimer, deathTimerMax);
                isDead = true;
            }
        }
    
           
         
       
            
       
    }

    void DeathTimer()
    {
        if(isDead)
        {
            if (innerDeathTimer >= 0)
            {
                innerDeathTimer -= Time.deltaTime;
            }
            else
            {
                GetComponent<Transform>().localScale = new Vector3(originalSize, originalSize, 1);
                isDead = false;
                GetComponent<Animator>().SetBool("IsDead", false);
                innerLifeTimer = Random.Range(lifeTimer, lifeTimerMax);

            }
        }
       
    }
}
