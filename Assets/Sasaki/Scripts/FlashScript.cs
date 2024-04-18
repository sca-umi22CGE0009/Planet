using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class FlashScript : MonoBehaviour
{
    [SerializeField, Header("点滅周期全体の時間")] private float totalTime = 1.0f;
    [SerializeField, Header("点滅周期")] private float flashTime = 0.5f; //点滅周期
    float resetTime; //リセットするまでの秒数

    private Renderer flashBlock; //オブジェクト
    private BoxCollider2D box;

    void Start()
    {
        flashBlock = GetComponent<Renderer>();
        box = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        resetTime += Time.deltaTime;

        //Memo
        //flashの値までtimeが増えたら0に戻す
        float repeatValue = Mathf.Repeat(resetTime, totalTime);

        //Memo
        //enabled: コンポーネントをアクティブ、非アクティブにするために使用
        //repeatValueが0.5より大きくなったらtrue
        flashBlock.enabled = repeatValue >= flashTime;

        box.enabled = repeatValue >= flashTime;
    }
}
