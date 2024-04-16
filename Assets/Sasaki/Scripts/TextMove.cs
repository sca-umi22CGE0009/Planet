using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMove : MonoBehaviour
{
    [Header ("フェードさせる時間")]
    [SerializeField]
    private float fadeTime = 1f;
    private CanvasGroup img;

    private bool check = false;

    private float time;
    void Start()
    {
        //alpha = 0 -> 透明
        //alpha = 1 -> 不透明
        img = GetComponent<CanvasGroup>();
        img.alpha = 0;
    }

    void Update()
    {
        //0だったら1にする
        if (!check)
        {
            img.alpha += fadeTime * Time.deltaTime;
            if (img.alpha == 1)
            {
                check = true;
            }
        }
        //1だったら0にする
        if (check)
        {
            img.alpha -= fadeTime * Time.deltaTime;
            if (img.alpha == 0)
            {
                check = false;
            }
        }
    }
}
