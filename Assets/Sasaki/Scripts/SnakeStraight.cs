using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class SnakeStraight : MonoBehaviour
{
    private GameObject player;
    [SerializeField, Header("�ւ̑��x")] private float moveSpeed = 2f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Direction();
    }

    void Update()
    {
        Vector2 pos = new Vector2(-moveSpeed * Time.deltaTime, 0);
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
        if (player != null && player.transform.position.x > this.transform.position.x)
        {
            Destroy(gameObject, 2f);
        }
    }
}
