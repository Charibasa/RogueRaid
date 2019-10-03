using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JZ_Trap : MonoBehaviour
{
    public string trapType;
    public GameManager GM;
    JY_Move player;
    JZ_Timer timing;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<JY_Move>();
        timing = GameObject.Find("Canvas").GetComponent<JZ_Timer>();
        //for instantly calling game end on insta death 
        //or we can set timeReduction float in JZ_Timer to 9999999 to make time count zero
        // GM.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        switch(trapType) {
            case "Trap Door":
                timing.reducetime(10f);
                break;
            case "Banana":
                timing.reducetime(999f);
                break;
            case "Dart":
                timing.reducetime(10f);
                break;
            case "Bear Trap":
                timing.reducetime(10f);
                break;
            case "Chest":
                timing.reducetime(10f);
                break;
            case "Poison":
                timing.reducetime(10f);
                break;
            case "Trip Wire":
                timing.reducetime(10f);
                break;                        
        }
        Destroy(gameObject);
    }
}
