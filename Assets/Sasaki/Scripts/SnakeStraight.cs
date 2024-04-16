using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class SnakeStraight : MonoBehaviour
{
    [SerializeField, Header("�ւ̑��x")]
    private float speed = 2f;

    void Start()
    {
        Direction();
    }

    //�L�����ړ�
    void Update()
    {
        Vector2 pos = new Vector2(-speed * Time.deltaTime, 0);
        transform.Translate(pos);
    }
    //�L�����̌���
    void Direction()
    {
        Vector2 lscale = gameObject.transform.localScale;
        lscale.x *= 1;
        gameObject.transform.localScale = lscale;
    }
    //�J�����O��������
    void OnBecameInvisible()
    {
        Destroy(this.gameObject,2f);
    }
}
