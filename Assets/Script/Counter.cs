using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("JackPortScore"))
        {
            GameManager.instance.AddScore(777);
        }
        else if (gameObject.CompareTag("100Score"))
        {
            GameManager.instance.AddScore(100);
        }
        else if (gameObject.CompareTag("50Score"))
        {
            GameManager.instance.AddScore(50);
        }

        CounterText.text = "Score : " + GameManager.instance.score;
    }
}
