using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Move : MonoBehaviour
{
    private bool m_CanMove;

    public bool CanMove
    {
        get
        {
            return m_CanMove;
        }

        set
        {
            m_CanMove = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CanMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 m = new Vector3(h, v, 0);

        Vector3 t = transform.position + m * Time.deltaTime * 5;

        if(CanMove)
        {
            transform.position = t;
        }
    }
}
