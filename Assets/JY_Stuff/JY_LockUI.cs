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
    public Button[] buttonLocks;
    public GameObject row2;

    GameObject player;
    GameObject score;

    private void OnEnable()
    {
        player = GameObject.Find("Player");
        score = GameObject.Find("ScoreText");

        locks = chest.numOfLocks;

        if(player.GetComponent<JY_Move>().hasSimple)
        {
            locks--;
        }
        else if(player.GetComponent<JY_Move>().hasDesimple)
        {
            locks++;
        }

        locksLeft = locks;
        unlocks = 0;

        for (int i = 0; i < 8; i++)
        {
            buttonLocks[i].gameObject.SetActive(false);

            if (locks > i)
            {
                buttonLocks[i].GetComponent<JY_Lock>().Dir = chest.locks[i];
                buttonLocks[i].interactable = true;
                buttonLocks[i].gameObject.SetActive(true);
            }
            else
            {
                buttonLocks[i].gameObject.SetActive(false);
            }

            if(i > 3)
            {
                row2.SetActive(true);
            }

            Debug.Log(buttonLocks[i].name + " " + buttonLocks[i].IsActive());
        }
        
        EventHandle.SetSelectedGameObject(buttonLocks[0].gameObject);
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
                EventHandle.SetSelectedGameObject(buttonLocks[1].gameObject);
            }
            else if (locks - locksLeft == 2 && locks > 2)
            {
                EventHandle.SetSelectedGameObject(buttonLocks[2].gameObject);
            }
            else if (locks - locksLeft == 3 && locks > 3)
            {
                EventHandle.SetSelectedGameObject(buttonLocks[3].gameObject);
            }
            else if (locks - locksLeft == 4 && locks > 4)
            {
                EventHandle.SetSelectedGameObject(buttonLocks[4].gameObject);
            }
            else if (locks - locksLeft == 5 && locks > 5)
            {
                EventHandle.SetSelectedGameObject(buttonLocks[5].gameObject);
            }
            else if (locks - locksLeft == 6 && locks > 6)
            {
                EventHandle.SetSelectedGameObject(buttonLocks[6].gameObject);
            }
            else if (locks - locksLeft == 7 && locks > 7)
            {
                EventHandle.SetSelectedGameObject(buttonLocks[7].gameObject);
            }
        }

        if(locksLeft==0)
        {
            if(unlocks==locks)
            {
                chest.isLocked = false;

                if (player.GetComponent<JY_Move>().hasSimple)
                {
                    score.GetComponent<JY_Score>().scoreValue += chest.pointValue * .8f;
                }
                else if (player.GetComponent<JY_Move>().hasDesimple)
                {
                    score.GetComponent<JY_Score>().scoreValue += chest.pointValue * 1.2f;
                }
                else
                {
                    score.GetComponent<JY_Score>().scoreValue += chest.pointValue;
                }
            }

            player.GetComponent<JY_Move>().CanMove = true;
            gameObject.SetActive(false);
        }
    }
}
