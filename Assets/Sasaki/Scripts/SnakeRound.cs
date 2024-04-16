using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeRound : MonoBehaviour
{
    [Header("x�̕�")]
    [SerializeField]
    private float width = 2; //��
    private float x; 
    [SerializeField]
    private float speed = 2f;

    private Vector2 snake; //�ւ̍��W�擾
    private GameObject player;

    bool rote;
    bool chack;
    void Start()
    {
        x = -speed;
        snake = transform.position;
        rote = false; //�����̃`�F�b�N
        chack = true; //�v���C���[�̈ʒu�`�F�b�N
        player = GameObject.Find("Player");
    }

    void Update()
    {
        //�L�����̌���
        Vector2 lscale = gameObject.transform.localScale;
        if ((lscale.x < 0 && !rote) || (lscale.x > 0 && rote))
        {
            lscale.x *= -1;
            gameObject.transform.localScale = lscale;
        }

        //�L�����ړ�
        Vector2 pos = new Vector2(x * Time.deltaTime, 0);
        transform.Translate(pos);

        ////player���ֈȏゾ������
        if (player.transform.position.x >= snake.x)
        {
            chack = false;
        }
        //else
        //{
        //    chack = true;
        //}
        //�ւ�width���ȉ���������
        if (this.transform.position.x <= snake.x - width && chack)
        {
            x = speed;
            chack = true;
            rote = true;
        }
        //�ւ�width�ȏゾ������
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
            //player-snake�L�����̈ʒu�֌W����������擾���A���x����艻
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

