using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MS_SpikeTrap : MonoBehaviour
{
    GameObject player;

    int tempSpeed;
    float timer = 5.0f;
    bool inCollider = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        tempSpeed = player.GetComponent<JY_Move>().speedUp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inCollider = true;
        player.GetComponent<JY_Move>().speedUp = tempSpeed - 2;
        if (inCollider == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;

                print("Working...");
                Invoke("TimeDamage", 2);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inCollider = false;
        timer = 5.0f;
        player.GetComponent<JY_Move>().speedUp = tempSpeed;
    }

    void TimeDamage()
    {
        //Time damage here
        print("Your time has been damaged.");
    }
}
