using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBar : MonoBehaviour
{
    /// <summary>
    /// ----注意点----
    /// rigidbody2dのgravityscaleを０にすること
    /// デバイスの問題で最初の下りの動作が瞬間移動のような挙動になっている。
    /// 要検証
    /// </summary>
    public float DownSpeed;
    public float UpSpeed;
    private Vector2 startPos;
    private Vector2 targetPos;
    [SerializeField] float _moveRange = 5.0f;
    [SerializeField] private bool isMovingUp = false;
    private bool isStop = false;
    private float stopDuration = 0.5f;

    void Start()
    {
        startPos = transform.position;
        targetPos = new Vector2(startPos.x, startPos.y - _moveRange);
    }

    void Update()
    {
        Vector2 pos = transform.position;

        if (!isStop)
        {
            if (!isMovingUp)
            {
                pos.y -= Time.deltaTime * DownSpeed;
                transform.position = pos;

                if (pos.y < targetPos.y)
                {
                    pos.y = targetPos.y;
                    isMovingUp = true;
                    isStop = true;
                    StartCoroutine(StopMovement(stopDuration)); // 上昇運動の停止を開始
                }
            }
            else
            {
                if (pos.y < startPos.y)
                {
                    pos.y += Time.deltaTime * UpSpeed;
                    transform.position = pos;
                }
                else
                {
                    pos.y = targetPos.y; // 目標位置まで到達したら位置を修正する
                    isMovingUp = false;
                    isStop = true;
                    StartCoroutine(StopMovement(stopDuration)); // 下降運動の停止を開始
                }
            }
        }
    }



    IEnumerator StopMovement(float duration)
    {
        yield return new WaitForSeconds(duration);
        isStop = false;
    }
}
