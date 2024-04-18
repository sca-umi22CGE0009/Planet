using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class TextMove : MonoBehaviour
{
    [SerializeField, Header("�t�F�[�h�����鎞��")] private float fadeTime = 1f;
    private CanvasGroup img;

    private bool fadeCheck = false;

    void Start()
    {
        img = GetComponent<CanvasGroup>();
        img.alpha = 0;
    }

    void Update()
    {
        //UI���t�F�[�h������
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
