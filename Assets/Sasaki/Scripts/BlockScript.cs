using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class BlockScript : MonoBehaviour
{
    [SerializeField, Header("プレイヤーが乗ってから消える判定をするまでの時間")] private float playerJadgmentTime = 1.0f;
    private float timeSave;
    [SerializeField, Header("プレイヤーが乗ってから消えるまでの時間")] private float moveTime = 0.5f;

    bool inCheck; //プレイヤーが触れているか

    void Start()
    {
        inCheck = false;
        timeSave = playerJadgmentTime;
    }

    void Update()
    {
        //プレイヤーが触れているとき
        if (inCheck)
        {
            timeSave -= Time.deltaTime;
            Debug.Log(timeSave);

            //Debug.Log(timeSave);
            //プレイヤーがplayerfadgmentTime秒乗っていたら
            if (timeSave < 0)
            {
                StartCoroutine(CoolTime());
            }
        }
        else
        {
            //初期化
            timeSave = playerJadgmentTime;
        }

    }

    //プレイヤーが触れたら
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inCheck = true;
        }
    }
    //触れていないとき
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inCheck = false;
        }
    }

    //消えるまでの時間判定
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(moveTime);
        this.gameObject.SetActive(false);
    }
}
