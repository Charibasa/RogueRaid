using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JY_TeleporterEntrance : MonoBehaviour
{
    public JY_TeleporterExit[] exits;

    int timesTeleported;
    bool teleported;
    Animator fade;
    Image fadeImage;
    Text floor;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        teleported = false;
        player = GameObject.Find("Player");
        floor = GameObject.Find("LevelText").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            int nextFloor = Random.Range(0, 9);

            if (!exits[nextFloor].hasBeenAccessed)
            {
                player.GetComponent<JY_Move>().CanMove = false;

                StartCoroutine(floorTransition(nextFloor));
            }
        }
    }

    IEnumerator floorTransition(int floor)
    {
        fade = GameObject.Find("Fade").GetComponent<Animator>();
        fadeImage = GameObject.Find("Fade").GetComponent<Image>();
        fade.SetBool("Fade", true);
        yield return new WaitUntil(() => fadeImage.color.a == 1);
        player.transform.position = exits[floor].transform.position;
        exits[floor].hasBeenAccessed = true;
        timesTeleported++;
        fade.SetBool("Fade", false);
        player.GetComponent<JY_Move>().CanMove = true;
    }
}
