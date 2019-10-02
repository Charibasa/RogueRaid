using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MS_BananaTrap : MonoBehaviour
{
    GameObject player;
    public GameManager GM;
    JZ_Timer timing;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        timing = GameObject.Find("Canvas").GetComponent<JZ_Timer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("DeathByBananaPeel", 0.1f); 
    }

    void DeathByBananaPeel()
    {
        player.GetComponent<JY_Move>().CanMove = false;
        timing.reducetime(999f);
        print("Death by banana peel");
        Destroy(gameObject);
    }
}
