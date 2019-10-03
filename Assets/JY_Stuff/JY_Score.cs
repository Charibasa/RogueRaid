using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JY_Score : MonoBehaviour
{
    public float scoreValue;
    public float addValue;
    // Update is called once per frame
    void Update()
    {
        if(addValue > 1000)
        {
            scoreValue += 1000;
            addValue += -1000;
        }
        else if (addValue > 100)
        {
            scoreValue += 100;
            addValue += -100;
        }
        else if (addValue > 10)
        {
            scoreValue += 10;
            addValue += -10;
        }
        else if (addValue > 0)
        {
            scoreValue += 1;
            addValue += -1;
        }

        if (scoreValue > 999999999)
        {
            gameObject.GetComponent<Text>().text = "999,999,999 g";
        }
        else
        {
            gameObject.GetComponent<Text>().text = string.Format("{0:n0}", scoreValue) + " g";
        }
    }
}
