using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class BlockScript : MonoBehaviour
{
    [SerializeField, Header("プレイヤーが乗ってから消えるまでの時間")] private float moveTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(CoolTime());
        }
    }
    //消えるまでの時間判定
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(moveTime);
        this.gameObject.SetActive(false);
    }
}
