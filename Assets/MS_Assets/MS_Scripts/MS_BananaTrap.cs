using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MS_BananaTrap : MonoBehaviour
{
    GameObject player;
    public GameManager GM;
    JZ_Timer timing;
    JY_SFXManager sound;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        timing = GameObject.Find("Canvas").GetComponent<JZ_Timer>();
        sound = GameObject.Find("SFXManager").GetComponent<JY_SFXManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            sound.playSound(1);

            if (player.GetComponent<JY_Move>().guardUp > 0)
            {
                player.GetComponent<JY_Move>().guardUp--;
            }
            else
            {
                player.GetComponent<JY_Move>().CanMove = false;
                timing.reducetime(999f);
            }

            Destroy(gameObject);
        }
    }
}
