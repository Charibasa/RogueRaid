using UnityEngine;

public class MS_TrapChest : MonoBehaviour
{
    public string chestType;
    public bool isLocked;
    public int numOfLocks;
    public int pointValue;
    public int[] locks;

    GameObject player;
    JY_LockUI lockUI;

    //MS Variables
    int saveSpeed;

    public GameManager GM;
    JZ_Timer timing;

    // Start is called before the first frame update
    void Start()
    {
        isLocked = true;
        locks = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        player = GameObject.Find("Player");
        lockUI = GameObject.Find("Canvas").GetComponentInChildren<JY_LockUI>(true);

        //MS Additions to Start
        saveSpeed = player.GetComponent<JY_Move>().speedUp;
        timing = GameObject.Find("Canvas").GetComponent<JZ_Timer>();

        switch (chestType)
        {
            case "Tier 1":
                numOfLocks = 2;
                pointValue = 150;
                break;
            case "Tier 2":
                numOfLocks = 3;
                pointValue = 400;
                break;
            case "Tier 3":
                numOfLocks = 4;
                pointValue = 1050;
                break;
            case "Tier 4":
                numOfLocks = 5;
                pointValue = 2800;
                break;
            case "Tier 5":
                numOfLocks = 6;
                pointValue = 7500;
                break;
            case "Tier 6":
                numOfLocks = 7;
                pointValue = 20000;
                break;
            default:
                numOfLocks = 2;
                pointValue = 100;
                break;
        }
    }

    private void Update()
    {
        if (!isLocked)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //MS Tags determine whether the chest is trapped or not
                if (this.tag == "Trapped")
                {
                    timing.reducetime(20f);
                    player.GetComponent<JY_Move>().speedUp = -4;
                    Invoke("SaveSpeed", 4);
                    Destroy(gameObject, 4);
                }
                else
                {
                    player.GetComponent<JY_Move>().CanMove = false;

                    for (int i = 0; i < 8; i++)
                    {
                        locks[i] = Random.Range(1, 5);
                    }

                    lockUI.chest = gameObject.GetComponent<JY_Chest>();
                    lockUI.gameObject.SetActive(true);
                }
            }
        }
    }

    void SaveSpeed()
    {
        player.GetComponent<JY_Move>().speedUp = saveSpeed;
        print("Your speed has returned to normal.");
    }
}
