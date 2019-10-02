using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Move : MonoBehaviour
{
    public bool CanMove;
    public int speedUp;
    public int speedBuff;
    public int guardUp;
    public bool hasSimple;
    public bool hasDesimple;

    // Start is called before the first frame update
    void Start()
    {
        speedUp = 0;
        CanMove = true;
        hasSimple = false;
        hasDesimple = false;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 m = new Vector3(h, v, 0);

        Vector3 t = transform.position + m * Time.deltaTime * (5 + speedUp + (speedBuff/2));

        if(CanMove)
        {
            transform.position = t;
        }
    }
}
