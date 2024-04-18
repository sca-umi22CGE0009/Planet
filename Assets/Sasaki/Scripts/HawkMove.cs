using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class HawkMove : MonoBehaviour
{
    private float time;
    [SerializeField, Header("��̑��x")] private float speed = 2; //�X�s�[�h
    [SerializeField, Header("x�̕�")] private float width= 4; //��
    [SerializeField, Header("y�̕�")] private float height= 1; //����
    Vector2 hawkPos;
    bool rote;

    void Start()
    {
        hawkPos = transform.position;
        rote = true;
    }

    void Update()
    {
        time -= speed * Time.deltaTime;

        //8�̎��ړ�
        transform.position = new Vector2(hawkPos.x + Mathf.Sin(time) * width, hawkPos.y + Mathf.Sin(time * 2) * height);

        //�L�����̌����C���l
        float s = 0.01f;

        //�L�����̌�������
        if (this.transform.position.x >= hawkPos.x + width - s)
        {
            rote = true;
        }
        else if (this.transform.position.x <= s - width + hawkPos.x)
        {
            rote = false;
        }

        Vector2 lscale = gameObject.transform.localScale;
        if ((lscale.x < 0 && rote) || (lscale.x > 0 && !rote))
        {
            lscale.x *= -1;
            gameObject.transform.localScale = lscale;
        }
    }
}
