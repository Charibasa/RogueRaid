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
        value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        value = Mathf.Clamp(value, 0, 5);

        SR.sprite = ranks[value];
    }
}
