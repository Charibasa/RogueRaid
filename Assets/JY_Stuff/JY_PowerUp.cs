﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_PowerUp : MonoBehaviour
{
    public string powerType;
    public float timeAdding = 10f;
    public GameManager GM;

    JY_Move player;
    JY_SFXManager sound;
    JZ_Timer timing;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<JY_Move>();
        sound = GameObject.Find("SFXManager").GetComponent<JY_SFXManager>();
        timing = GameObject.Find("Canvas").GetComponent<JZ_Timer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sound.playSound(4);

        switch(powerType)
        {
            case "Speed":
                if(player.speedBuff < 5)
                {
                    player.speedBuff++;
                }
                break;
            case "Guard":
                if(player.guardUp < 5)
                {
                    player.guardUp++;
                }
                break;
            case "Simplifier":
                player.hasSimple = true;
                player.hasDesimple = false;
                break;
            case "Desimplifier":
                player.hasSimple = false;
                player.hasDesimple = true;
                break;
            case "Time":
                //code to increase timer by 10 seconds
                timing.addtime(timeAdding);
                break;
        }

        Destroy(gameObject);
    }
}
