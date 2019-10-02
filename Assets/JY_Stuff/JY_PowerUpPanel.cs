using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_PowerUpPanel : MonoBehaviour
{
    GameObject player;
    public JY_PowerUpImage SpeedImage;
    public JY_PowerUpImage DeSimpleImage;
    public JY_PowerUpImage GuardImage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        SpeedImage.value = player.GetComponent<JY_Move>().speedBuff;

        if(player.GetComponent<JY_Move>().hasSimple)
        {
            DeSimpleImage.value = 1;
        }
        else if(player.GetComponent<JY_Move>().hasDesimple)
        {
            DeSimpleImage.value = 2;
        }
        else
        {
            DeSimpleImage.value = 0;
        }

        GuardImage.value = player.GetComponent<JY_Move>().guardUp;
    }
}
