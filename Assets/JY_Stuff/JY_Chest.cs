using UnityEngine;

public class JY_Chest: MonoBehaviour
{
    public string chestType;
    public bool isLocked;
    public int numOfLocks;
    public int pointValue;
    public int[] locks;

    GameObject player;
    JY_LockUI lockUI;
    
    // Start is called before the first frame update
    void Start()
    {
        isLocked = true;
        locks = new int[] { 0, 0, 0, 0, 0 };
        player = GameObject.Find("Player");
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
                numOfLocks = 5;
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
        if(collision.gameObject.name == "Player")
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                player.GetComponent<JY_Move>().CanMove = false;

                for (int i = 0; i < 5; i++)
                {
                    locks[i] = Random.Range(1, 5);
                }
                
                lockUI.chest = gameObject.GetComponent<JY_Chest>();
                lockUI.gameObject.SetActive(true);
            }
        }
    }
}
