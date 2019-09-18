using UnityEngine;

public class JY_Chest: MonoBehaviour
{
    public string chestType;
    public bool isLocked;
    public int numOfLocks;
    public int pointValue;
    public int[] locks = { 0, 0, 0, 0 };

    GameObject player;
    JY_LockUI lockUI;
    
    // Start is called before the first frame update
    void Start()
    {
        isLocked = true;
        player = GameObject.Find("JY_Player");
        lockUI = GameObject.Find("Canvas").GetComponentInChildren<JY_LockUI>(true);

        switch(chestType.ToLower())
        {
            case "small":
                numOfLocks = 2;
                pointValue = 150;
                break;
            case "medium":
                numOfLocks = 3;
                pointValue = 400;
                break;
            case "large":
                numOfLocks = 4;
                pointValue = 900;
                break;
            default:
                numOfLocks = 1;
                pointValue = 50;
                break;
        }
    }
    
    private void Update()
    {
        if(!isLocked)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "JY_Player")
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                player.GetComponent<JY_Move>().CanMove = false;

                for (int i = 0; i < numOfLocks; i++)
                {
                    locks[i] = Random.Range(1, 5);
                }
                
                lockUI.chest = gameObject.GetComponent<JY_Chest>();
                lockUI.gameObject.SetActive(true);
            }
        }
    }
}
