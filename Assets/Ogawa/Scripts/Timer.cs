using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeTexts;
    [SerializeField] float totalTime = 31.0f;
    int retime;

    void Start()
    {
        totalTime = 31.0f;
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        retime = (int)totalTime;
        timeTexts.text = retime.ToString();
        if (retime <= 0)
        {
            //gameover
            totalTime = 0;
        }
    }
}
