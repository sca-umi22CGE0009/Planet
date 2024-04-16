using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMove : MonoBehaviour
{
    [Header ("�t�F�[�h�����鎞��")]
    [SerializeField]
    private float fadeTime = 1f;
    private CanvasGroup img;

    private bool check = false;

    private float time;
    void Start()
    {
        //alpha = 0 -> ����
        //alpha = 1 -> �s����
        img = GetComponent<CanvasGroup>();
        img.alpha = 0;
    }

    void Update()
    {
        //0��������1�ɂ���
        if (!check)
        {
            img.alpha += fadeTime * Time.deltaTime;
            if (img.alpha == 1)
            {
                check = true;
            }
        }
        //1��������0�ɂ���
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
