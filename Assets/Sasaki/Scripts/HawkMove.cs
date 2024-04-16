using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HawkMove : MonoBehaviour
{
    private float time;
    [SerializeField]
    private float speed = 2; //�X�s�[�h

    [SerializeField, Header("x�̕�")]
    private float width= 4; //��

    [SerializeField, Header("����")]
    private float height= 1; //����

    Vector2 pos;

    bool rote;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        rote = true;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime * speed;

        //���̎��ړ�
        transform.position = new Vector2(pos.x + Mathf.Sin(time) * width, pos.y + Mathf.Sin(time * 2) * height);

        //x�̔���

        if (this.transform.position.x >= pos.x + width - 0.01f)
        {
            rote = true;
        }
        else if (this.transform.position.x <= 0.01f - width + pos.x)
        {
            rote = false;
        }

        //�L�����̌���
        Vector2 lscale = gameObject.transform.localScale;
        if ((lscale.x < 0 && rote) || (lscale.x > 0 && !rote))
        {
            lscale.x *= -1;
            gameObject.transform.localScale = lscale;
        }
    }
}
