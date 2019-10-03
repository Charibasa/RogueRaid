using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JZ_Timer : MonoBehaviour
{
    // public float timeReduction = 0f;
    // public float timeAddition = 0f;
    public float roundTime = 2f;
    public float countdown = 2f;
    public GameManager GM;

    public Text roundTimerTxt;
    void Start()
    {
        countdown = roundTime;  
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            GM.endGame();
        }
        // countdown -= timeReduction;
        // countdown += timeAddition;
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown,0f,Mathf.Infinity);
        roundTimerTxt.text = string.Format("{0:00.0}", countdown);
    }
    public void addtime(float timeAdding) {
        // Debug.Log("Called Add time");
        countdown += timeAdding;
        // Debug.Log(timeleft);
        // return timeleft;
    }
    public void reducetime(float timeReducing) {
        countdown -= timeReducing; 
    }
}
