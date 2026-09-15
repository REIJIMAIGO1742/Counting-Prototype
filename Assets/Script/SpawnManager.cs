using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager sharedInStance;
    public List<GameObject> pooledObject;
    public GameObject ballPrefab;

    public Text pinBallText;

    public int amountToPool;
    private int forCount;


    private void Awake()
    {
        sharedInStance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        forCount = amountToPool;
        pooledObject = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(ballPrefab);
            obj.SetActive(false);
            pooledObject.Add(obj);
            obj.transform.SetParent(this.transform);
        }

        pinBallText.text = "PinBall : " + forCount;
    }

    public GameObject GetpooledObject()
    {
        for (int i = 0; i < pooledObject.Count; i++)
        {
            if (!pooledObject[i].activeInHierarchy)
            {
                forCount--;
                pinBallText.text = "PinBall : " + forCount;
                return pooledObject[i];
            }
        }

        return null;
    
    }

}
