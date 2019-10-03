using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JY_TeleporterEntrance : MonoBehaviour
{
    public JY_TeleporterExit exit;
    public bool increments;
    Animator fade;
    Image fadeImage;
    Text floor;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        floor = GameObject.Find("LevelText").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == player)
        {
            player.GetComponent<JY_Move>().CanMove = false;

            StartCoroutine(floorTransition());
        }
    }

    IEnumerator floorTransition()
    {
        fade = GameObject.Find("Fade").GetComponent<Animator>();
        fadeImage = GameObject.Find("Fade").GetComponent<Image>();
        fade.SetBool("Fade", true);
        yield return new WaitUntil(() => fadeImage.color.a == 1);
        player.transform.position = exit.transform.position;
        fade.SetBool("Fade", false);
        player.GetComponent<JY_Move>().CanMove = true;
        if(increments)
        {
            floor.text = "" + (int.Parse(floor.text) + 1);
        }
    }
}
