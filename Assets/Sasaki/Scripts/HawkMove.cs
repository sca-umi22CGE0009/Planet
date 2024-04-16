using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HawkMove : MonoBehaviour
{
    private float time;
    [SerializeField]
    private float speed = 2; //スピード

    [SerializeField, Header("xの幅")]
    private float width= 4; //幅

    [SerializeField, Header("高さ")]
    private float height= 1; //高さ

    Vector2 pos;

    bool rote;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        rote = true;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime * speed;

        //八の字移動
        transform.position = new Vector2(pos.x + Mathf.Sin(time) * width, pos.y + Mathf.Sin(time * 2) * height);

        //xの判定

        if (this.transform.position.x >= pos.x + width - 0.01f)
        {
            rote = true;
        }
        else if (this.transform.position.x <= 0.01f - width + pos.x)
        {
            rote = false;
        }

        //キャラの向き
        Vector2 lscale = gameObject.transform.localScale;
        if ((lscale.x < 0 && rote) || (lscale.x > 0 && !rote))
        {
            lscale.x *= -1;
            gameObject.transform.localScale = lscale;
        }
    }
}
