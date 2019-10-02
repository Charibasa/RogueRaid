using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JY_PowerUpImage : MonoBehaviour
{
    public Sprite[] ranks;
    private Image SR;
    public int value;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        SR.sprite = ranks[value];
    }
}
