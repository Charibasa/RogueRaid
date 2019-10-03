using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_PowerUp : MonoBehaviour
{
    public string powerType;
    public float timeAdding = 10f;

    JY_Move player;
    JZ_Timer timing;
    // public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<JY_Move>();
        timing = GameObject.Find("Canvas").GetComponent<JZ_Timer>();
        //for instantly calling game end on insta death 
        //or we can set timeReduction float in JZ_Timer to 9999999 to make time count zero
        // GM.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
                Debug.Log("Calling Add time");
                timing.addtime(timeAdding);
                break;
        }

        Destroy(gameObject);
    }
}
