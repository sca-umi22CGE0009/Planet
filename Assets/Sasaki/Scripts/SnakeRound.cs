using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeRound : MonoBehaviour
{
    [SerializeField, Header("xの幅")] private float width = 2; //幅
    private float snakeX; 
    [SerializeField, Header("蛇の速度")] private float moveSpeed = 2f;

    private Vector2 snake; //蛇の座標取得
    private GameObject player;

    bool rote; //向きのチェック
    bool chack; //プレイヤーの位置チェック

    void Start()
    {
        snakeX = -moveSpeed;
        snake = transform.position;
        rote = false; 
        chack = true; 
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector2 pos = new Vector2(snakeX * Time.deltaTime, 0);
        transform.Translate(pos);

        ////playerが蛇以上だったら
        if (player.transform.position.x >= snake.x)
        {
            chack = false;
        }
        //playerのx座標が蛇のx座標より大きくなったら追いかける
        if (!chack)
        {
            //chack = false;
            rote = true;
            //player-snakeキャラの位置関係から方向を取得し、速度を一定化
            Vector2 targeting = (player.transform.position -
                                    this.transform.position).normalized;
            snakeX = moveSpeed * targeting.x;

            if (player.transform.position.x <= snake.x)
            {
                rote = false;
                snakeX = moveSpeed * targeting.x;
            }
        }

        //蛇がwidthより以下だったら
        if (this.transform.position.x <= snake.x - width && chack)
        {
            snakeX = moveSpeed;
            chack = true;
            rote = true;
        }
        //蛇がwidth以上だったら
        else if (this.transform.position.x >= snake.x + width && chack)
        {
            snakeX = -moveSpeed;
            chack = true;
            rote = false;
        }

        //キャラの向き
        Vector2 lscale = gameObject.transform.localScale;
        if ((lscale.x < 0 && !rote) || (lscale.x > 0 && rote))
        {
            lscale.x *= -1;
            gameObject.transform.localScale = lscale;
        }
    }
}

