using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JY_Score : MonoBehaviour
{
    public int scoreValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreValue > 9999999)
        {
            gameObject.GetComponent<Text>().text = "9,999,999 g";
        }
        else
        {
            gameObject.GetComponent<Text>().text = string.Format("{0:n0}", scoreValue) + " g";
        }
    }
}
