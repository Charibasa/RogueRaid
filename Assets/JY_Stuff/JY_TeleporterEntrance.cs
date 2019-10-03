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
    Text zone;
    GameObject player;
    JY_SFXManager sound;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        zone = GameObject.Find("LevelText").GetComponent<Text>();
        sound = GameObject.Find("SFXManager").GetComponent<JY_SFXManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            player.GetComponent<JY_Move>().CanMove = false;
            sound.playSound(5);
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
            zone.text = "" + (int.Parse(zone.text) + 1);
        }
    }
}
