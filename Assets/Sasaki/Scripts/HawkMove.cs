using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class HawkMove : MonoBehaviour
{
    private float time;
    [SerializeField, Header("鷹の速度")] private float speed = 2; //スピード
    [SerializeField, Header("xの幅")] private float width= 4; //幅
    [SerializeField, Header("yの幅")] private float height= 1; //高さ
    Vector2 hawkPos;
    bool rote;

    void Start()
    {
        hawkPos = transform.position;
        rote = true;
    }

    void Update()
    {
        time -= speed * Time.deltaTime;

        //8の字移動
        transform.position = new Vector2(hawkPos.x + Mathf.Sin(time) * width, hawkPos.y + Mathf.Sin(time * 2) * height);

        //キャラの向き修正値
        float s = 0.01f;

        //キャラの向き判定
        if (this.transform.position.x >= hawkPos.x + width - s)
        {
            rote = true;
        }
        else if (this.transform.position.x <= s - width + hawkPos.x)
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
