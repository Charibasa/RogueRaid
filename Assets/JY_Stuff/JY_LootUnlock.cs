using UnityEngine;

public class JY_LootUnlock : MonoBehaviour
{
    public string LootType;
    public GameObject Player;
    public GameObject PuzzleInter;
    public bool Locked;
    private int m_NumOfLocks;
    private int[] m_Locks = { 0, 0, 0, 0 };

    public int NumOfLocks
    {
        get
        {
            return m_NumOfLocks;
        }
    }

    public int[] Locks
    {
        get
        {
            return m_Locks;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Locked = true;

        switch(LootType.ToLower())
        {
            case "small":
                m_NumOfLocks = 2;
                break;
            case "medium":
                m_NumOfLocks = 3;
                break;
            case "large":
                m_NumOfLocks = 4;
                break;
            default:
                m_NumOfLocks = 1;
                break;
        }
    }
    
    private void Update()
    {
        if(!Locked)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "JY_TestPlayer")
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Player.GetComponent<JY_Move>().CanMove = false;

                for (int i = 0; i < NumOfLocks; i++)
                {
                    m_Locks[i] = Random.Range(1, 5);
                }

                PuzzleInter.SetActive(true);
            }
        }
    }
}
