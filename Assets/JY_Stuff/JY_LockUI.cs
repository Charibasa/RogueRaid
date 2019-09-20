using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JY_LockUI : MonoBehaviour
{
    public JY_Chest chest;
    public int locks;
    public int locksLeft;
    public int unlocks;
    public int input;
    public EventSystem EventHandle;
    public Button Lock1;
    public Button Lock2;
    public Button Lock3;
    public Button Lock4;
    public Button Lock5;

    GameObject player;
    GameObject score;

    private void OnEnable()
    {
        player = GameObject.Find("Player");
        score = GameObject.Find("ScoreText");

        locks = chest.numOfLocks;
        locksLeft = locks;
        unlocks = 0;
        Lock1.gameObject.SetActive(false);
        Lock2.gameObject.SetActive(false);
        Lock3.gameObject.SetActive(false);
        Lock4.gameObject.SetActive(false);
        Lock5.gameObject.SetActive(false);

        Lock1.GetComponent<JY_Lock>().Dir = chest.locks[0];
        Lock1.interactable = true;
        Lock1.gameObject.SetActive(true);

        if(locks > 1)
        {
            Lock2.GetComponent<JY_Lock>().Dir = chest.locks[1];
            Lock2.interactable = true;
            Lock2.gameObject.SetActive(true);

            if (locks > 2)
            {
                Lock3.GetComponent<JY_Lock>().Dir = chest.locks[2];
                Lock3.interactable = true;
                Lock3.gameObject.SetActive(true);

                if (locks > 3)
                {
                    Lock4.GetComponent<JY_Lock>().Dir = chest.locks[3];
                    Lock4.interactable = true;
                    Lock4.gameObject.SetActive(true);

                    if (locks > 4)
                    {
                        Lock5.GetComponent<JY_Lock>().Dir = chest.locks[4];
                        Lock5.interactable = true;
                        Lock5.gameObject.SetActive(true);
                    }
                }
            }
        }


        EventHandle.SetSelectedGameObject(Lock1.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                input = 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                input = 2;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                input = 3;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                input = 4;
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                locksLeft = 1;
            }

            if (EventHandle.currentSelectedGameObject.GetComponent<JY_Lock>().Dir == input)
            {
                unlocks++;
            }

            locksLeft--;
            EventHandle.currentSelectedGameObject.GetComponent<Button>().interactable = false;
            
            if (locks - locksLeft == 1)
            {
                EventHandle.SetSelectedGameObject(Lock2.gameObject);
            }
            else if (locks - locksLeft == 2 && locks > 2)
            {
                EventHandle.SetSelectedGameObject(Lock3.gameObject);
            }
            else if (locks - locksLeft == 3 && locks > 3)
            {
                EventHandle.SetSelectedGameObject(Lock4.gameObject);
            }
            else if (locks - locksLeft == 4 && locks > 4)
            {
                EventHandle.SetSelectedGameObject(Lock5.gameObject);
            }
        }

        if(locksLeft==0)
        {
            if(unlocks==locks)
            {
                chest.isLocked = false;
                score.GetComponent<JY_Score>().scoreValue += chest.pointValue;
            }
            else
            {

            }

            player.GetComponent<JY_Move>().CanMove = true;
            gameObject.SetActive(false);
        }
    }
}
