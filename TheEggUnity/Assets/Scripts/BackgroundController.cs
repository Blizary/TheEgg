using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float faceTimer;
    [SerializeField] private float faceTimerMax;

    private float innerFaceTimer;
    // Start is called before the first frame update
    void Start()
    {
        innerFaceTimer = Random.Range(faceTimer, faceTimerMax);
    }

    // Update is called once per frame
    void Update()
    {
        FaceTimer();
    }

    void FaceTimer()
    {
        if(innerFaceTimer>=0)
        {
            innerFaceTimer -= Time.deltaTime;
        }
        else
        {
            GetComponent<Animator>().SetTrigger("ShowFace");
            innerFaceTimer = Random.Range(faceTimer, faceTimerMax);
        }
    }
}
