using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class SnakeStraight : MonoBehaviour
{
    [SerializeField, Header("蛇の速度")]
    private float speed = 2f;

    void Start()
    {
        Direction();
    }

    //キャラ移動
    void Update()
    {
        Vector2 pos = new Vector2(-speed * Time.deltaTime, 0);
        transform.Translate(pos);
    }
    //キャラの向き
    void Direction()
    {
        Vector2 lscale = gameObject.transform.localScale;
        lscale.x *= 1;
        gameObject.transform.localScale = lscale;
    }
    //カメラ外だったら
    void OnBecameInvisible()
    {
        Destroy(this.gameObject,2f);
    }
}
