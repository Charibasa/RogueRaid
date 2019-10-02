using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MS_SpikeTrap : MonoBehaviour
{
    GameObject player;
    public GameManager GM;
    JZ_Timer timing;

    int tempSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        timing = GameObject.Find("Canvas").GetComponent<JZ_Timer>();

        tempSpeed = player.GetComponent<JY_Move>().speedUp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<JY_Move>().speedUp = tempSpeed - 2;
        Invoke("TimeDamage", 0.5f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.GetComponent<JY_Move>().speedUp = tempSpeed;
    }

    void TimeDamage()
    {
        timing.reducetime(10f);
        print("Your time has been damaged.");
    }
}
