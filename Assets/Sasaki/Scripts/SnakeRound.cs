using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeRound : MonoBehaviour
{
    [Header("xの幅")]
    [SerializeField]
    private float width = 2; //幅
    private float x; 
    [SerializeField]
    private float speed = 2f;

    private Vector2 snake; //蛇の座標取得
    private GameObject player;

    bool rote;
    bool chack;
    void Start()
    {
        x = -speed;
        snake = transform.position;
        rote = false; //向きのチェック
        chack = true; //プレイヤーの位置チェック
        player = GameObject.Find("Player");
    }

    void Update()
    {
        //キャラの向き
        Vector2 lscale = gameObject.transform.localScale;
        if ((lscale.x < 0 && !rote) || (lscale.x > 0 && rote))
        {
            lscale.x *= -1;
            gameObject.transform.localScale = lscale;
        }

        //キャラ移動
        Vector2 pos = new Vector2(x * Time.deltaTime, 0);
        transform.Translate(pos);

        ////playerが蛇以上だったら
        if (player.transform.position.x >= snake.x)
        {
            chack = false;
        }
        //else
        //{
        //    chack = true;
        //}
        //蛇がwidthより以下だったら
        if (this.transform.position.x <= snake.x - width && chack)
        {
            x = speed;
            chack = true;
            rote = true;
        }
        //蛇がwidth以上だったら
        else if (this.transform.position.x >= snake.x + width && chack)
        {
            x = -speed;
            chack = true;
            rote = false;
        }
        if (!chack)
        {
            chack = false;
            rote = true;
            //player-snakeキャラの位置関係から方向を取得し、速度を一定化
            Vector2 targeting = (player.transform.position -
                                    this.transform.position).normalized;
            x = speed * targeting.x;

            if (player.transform.position.x <= snake.x)
            {
                rote = false;
                x = speed * targeting.x;
            }
        }
    }
}

