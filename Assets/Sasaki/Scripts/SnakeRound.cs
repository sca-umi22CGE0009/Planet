using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeRound : MonoBehaviour
{
    [SerializeField, Header("x�̕�")]
    private float width = 2; //��
    private float x; 
    [SerializeField, Header("�ւ̑��x")]
    private float speed = 2f;

    private Vector2 snake; //�ւ̍��W�擾
    private GameObject player;

    bool rote; //�����̃`�F�b�N
    bool chack; //�v���C���[�̈ʒu�`�F�b�N

    void Start()
    {
        x = -speed;
        snake = transform.position;
        rote = false; 
        chack = true; 
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector2 pos = new Vector2(x * Time.deltaTime, 0);
        transform.Translate(pos);

        ////player���ֈȏゾ������
        if (player.transform.position.x >= snake.x)
        {
            chack = false;
        }
        //player��x���W���ւ�x���W���傫���Ȃ�����ǂ�������
        if (!chack)
        {
            //chack = false;
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

        //�L�����̌���
        Vector2 lscale = gameObject.transform.localScale;
        if ((lscale.x < 0 && !rote) || (lscale.x > 0 && rote))
        {
            lscale.x *= -1;
            gameObject.transform.localScale = lscale;
        }
    }
}

