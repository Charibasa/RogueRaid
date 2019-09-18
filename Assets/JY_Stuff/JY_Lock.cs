using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JY_Lock : MonoBehaviour
{
    public Sprite Up;
    public Sprite Right;
    public Sprite Down;
    public Sprite Left;
    public int Dir;
    private Image SR;

    // Start is called before the first frame update
    private void OnEnable()
    {
        SR = GetComponent<Image>();

        switch (Dir)
        {
            case (1):
                SR.sprite = Up;
                break;
            case (2):
                SR.sprite = Right;
                break;
            case (3):
                SR.sprite = Down;
                break;
            case (4):
                SR.sprite = Left;
                break;
        }
    }
}
