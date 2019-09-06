using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JY_UnlockUI : MonoBehaviour
{
    public JY_LootUnlock Loot;
    public int Locks;
    public int LocksLeft;
    public int Unlocks;
    public int Press;
    public EventSystem EventHandle;
    public Button Lock1;
    public Button Lock2;
    public Button Lock3;
    public Button Lock4;

    private void OnEnable()
    {
        Locks = Loot.NumOfLocks;
        LocksLeft = Locks;
        Unlocks = 0;
        
        Lock1.GetComponent<JY_Button>().Dir = Loot.Locks[0];
        Lock1.interactable = true;
        Lock2.GetComponent<JY_Button>().Dir = Loot.Locks[1];
        Lock2.interactable = true;

        if (Locks>2)
        {
            Lock3.GetComponent<JY_Button>().Dir = Loot.Locks[2];
            Lock3.interactable = true;

            if (Locks>3)
            {
                Lock4.GetComponent<JY_Button>().Dir = Loot.Locks[3];
                Lock4.interactable = true;
            }
        }

        EventHandle.SetSelectedGameObject(Lock1.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Press = 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Press = 2;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Press = 3;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Press = 4;
            }

            if (EventHandle.currentSelectedGameObject.GetComponent<JY_Button>().Dir == Press)
            {
                Unlocks++;
                EventHandle.currentSelectedGameObject.GetComponent<Image>().color = new Color(100, 255, 100);
            }
            else
            {
                EventHandle.currentSelectedGameObject.GetComponent<Image>().color = new Color(255, 100, 100);
            }

            LocksLeft--;
            EventHandle.currentSelectedGameObject.GetComponent<Button>().interactable = false;
            
            if(Locks-LocksLeft==1)
            {
                EventHandle.SetSelectedGameObject(Lock2.gameObject);
            }
            else if(Locks-LocksLeft==2&&Locks>2)
            {
                EventHandle.SetSelectedGameObject(Lock3.gameObject);
            }
            else if(Locks-LocksLeft==3&&Locks>3)
            {
                EventHandle.SetSelectedGameObject(Lock4.gameObject);
            }
        }

        if(LocksLeft==0)
        {
            if(Unlocks==Locks)
            {
                Debug.Log("You're Winner!");
                Loot.Locked = false;
            }
            else
            {
                Debug.Log("You're Loser!");
            }

            Loot.Player.GetComponent<JY_Move>().CanMove = true;
            gameObject.SetActive(false);
        }
    }
}
