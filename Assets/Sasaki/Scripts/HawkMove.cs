using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class HawkMove : MonoBehaviour
{
    private float time;
    [SerializeField,Header("鷹の速度")]
    private float speed = 2; //スピード

    [SerializeField, Header("xの幅")]
    private float width= 4; //幅

    [SerializeField, Header("yの幅")]
    private float height= 1; //高さ

    Vector2 pos;

    bool rote;

    void Start()
    {
        pos = transform.position;
        rote = true;
    }

    void Update()
    {
        time -= speed * Time.deltaTime;

        //8の字移動
        transform.position = new Vector2(pos.x + Mathf.Sin(time) * width, pos.y + Mathf.Sin(time * 2) * height);

        //修正の値
        float s = 0.01f;

        //キャラの向き判定
        if (this.transform.position.x >= pos.x + width - s)
        {
            rote = true;
        }
        else if (this.transform.position.x <= s - width + pos.x)
        {
            rote = false;
        }

        Vector2 lscale = gameObject.transform.localScale;
        if ((lscale.x < 0 && rote) || (lscale.x > 0 && !rote))
        {
            lscale.x *= -1;
            gameObject.transform.localScale = lscale;
        }
    }
}
