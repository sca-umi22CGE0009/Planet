using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class BlockScript : MonoBehaviour
{
    [SerializeField, Header("�v���C���[������Ă��������܂ł̎���")] private float moveTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(CoolTime());
        }
    }
    //������܂ł̎��Ԕ���
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(moveTime);
        this.gameObject.SetActive(false);
    }
}
