using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{

    [SerializeField] private List<Sprite> eggphases;
    [SerializeField] private List<float> speed; //speed for each corresponding phase

    [SerializeField] private float lifeTimer;
    private float innerLifeTimer;
    private int currentPhase;

    private Rigidbody2D rBody;
    private float stayInSameDirection;


    // Start is called before the first frame update
    void Start()
    {
        //Get 1st sprite
        currentPhase = 0;
        GetComponent<SpriteRenderer>().sprite = eggphases[currentPhase];
        //add abit of random to the set timer for difference between eggs
        innerLifeTimer = Random.Range(-lifeTimer * 0.2f, lifeTimer * 0.2f);
        rBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        ChangeSprite();
    }


    /// <summary>
    /// Simple random movement
    /// </summary>
    void Movement()
    {
        //rBody.MovePosition(new Vector2((transform.position.x + Input.GetAxisRaw("Horizontal") * moveSpd * Time.deltaTime), (transform.position.y + Input.GetAxisRaw("Vertical") * moveSpd * Time.deltaTime)));
    }


    /// <summary>
    /// Timer to change the sprite when the life timer ends
    /// </summary>
    void ChangeSprite()
    {
        if(innerLifeTimer>=0)
        {
            innerLifeTimer -= Time.deltaTime;
        }
        else
        {
            //reset timer
            innerLifeTimer = Random.Range(-lifeTimer * 0.2f, lifeTimer * 0.2f);

            //change sprite
            //check if random died
            int died = Random.Range(0, 10);
            Debug.Log(died);
            if(died==0)
            {
                Debug.Log("sudden death");
                currentPhase = 0;
            }
            else
            {
                currentPhase += 1;
                if (currentPhase >= eggphases.Count)
                {
                    currentPhase = 0;
                }
            }
            
            GetComponent<SpriteRenderer>().sprite = eggphases[currentPhase];
        }
    }
}
