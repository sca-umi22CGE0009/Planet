using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class TextMove : MonoBehaviour
{
    [SerializeField, Header("フェードさせる時間")] private float fadeTime = 1f;
    private CanvasGroup img;

    private bool fadeCheck = false;

    void Start()
    {
        img = GetComponent<CanvasGroup>();
        img.alpha = 0;
    }

    void Update()
    {
        //UIをフェードさせる
        if (!fadeCheck)
        {
            img.alpha += fadeTime * Time.deltaTime;
            if (img.alpha == 1)
            {
                fadeCheck = true;
            }
        }
        else
        {
            img.alpha -= fadeTime * Time.deltaTime;
            if (img.alpha == 0)
            {
                fadeCheck = false;
            }
        }
    }
}
