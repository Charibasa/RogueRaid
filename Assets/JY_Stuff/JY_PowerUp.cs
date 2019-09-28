using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_PowerUp : MonoBehaviour
{
    public string powerType;

    JY_Move player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<JY_Move>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(powerType)
        {
            case "Speed":
                player.speedUp++;
                break;
            case "Guard":
                player.guardUp++;
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
                break;
        }

        Destroy(gameObject);
    }
}
