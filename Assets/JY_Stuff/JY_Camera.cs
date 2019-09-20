using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Camera : MonoBehaviour
{
    GameObject player;
    Vector2 playerLocation;
    Vector2 roomCenter;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        roomCenter = new Vector2(0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        playerLocation = new Vector2(player.transform.position.x, player.transform.position.y);

        if (playerLocation.x > roomCenter.x + 5)
        {
            roomCenter.x += 10;
            transform.position += new Vector3(10, 0, 0);
        }

        if (playerLocation.x < roomCenter.x - 5)
        {
            roomCenter.x += -10;
            transform.position += new Vector3(-10, 0, 0);
        }

        if (playerLocation.y > roomCenter.y + 4.5f)
        {
            roomCenter.y += 9.0f;
            transform.position += new Vector3(0, 9.0f, 0);
        }

        if (playerLocation.y < roomCenter.y - 4.5f)
        {
            roomCenter.y += -9.0f;
            transform.position += new Vector3(0, -9.0f, 0);
        }
    }
}
