using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MS_BananaTrap : MonoBehaviour
{
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("DeathByBananaPeel", 1);
    }

    void DeathByBananaPeel()
    {
        // Time damage here

        // Something along the lines of 
        // Current time - current time
        // Or give them hope? Maybe...
        // Current time - (Current time - 5)

        print("Death by banana peel");
    }
}
