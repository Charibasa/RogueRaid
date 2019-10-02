﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JY_Score : MonoBehaviour
{
    public float scoreValue;

    // Update is called once per frame
    void Update()
    {
        if(scoreValue > 999999999)
        {
            gameObject.GetComponent<Text>().text = "999,999,999 g";
        }
        else
        {
            gameObject.GetComponent<Text>().text = string.Format("{0:n0}", scoreValue) + " g";
        }
    }
}
