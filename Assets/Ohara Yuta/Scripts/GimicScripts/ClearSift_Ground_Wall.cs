using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSift_Ground_Wall : MonoBehaviour
{
    [SerializeField] private bool _clear = true; //�������ǂ���
    [SerializeField , Header("��ɂ��蔲����")] private bool _checkThrough = false;
    [SerializeField, Header("��ɂ��蔲���Ȃ�")] private bool _notThrough = false;
    private bool _through = false; //���蔲���̔���

    private GameObject _switcClearSift = null;
    private Switch_ClearSift switch_ClearSift = null;

    private SpriteRenderer spriteRenderer;
    private Color _blockColor;

    private BoxCollider2D boxCollider2;

    // Start is called before the first frame update
    void Start()
    {
        _switcClearSift = GameObject.FindGameObjectWithTag("Switch");
        switch_ClearSift = _switcClearSift.GetComponent<Switch_ClearSift>();

        boxCollider2 = GetComponent<BoxCollider2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        _blockColor = spriteRenderer.material.color;

        ClearSift();

        if (_checkThrough)
        {
            boxCollider2.isTrigger = true;
            this.tag = "Empty";
        }
        else if (_notThrough)
        {
            boxCollider2.isTrigger = false;
            this.tag = "Ground";
        }
    }

    // Update is called once per frame
    void Update()
    {
        ClearSift();

        if (!_checkThrough && !_notThrough)
        {
            CheckThrough();
        }
    }

    void ClearSift()
    {
        if (switch_ClearSift.GetClear())
        {
            //�ŏ��ɓ����������u���b�N�𔽓]
            // spriteRenderer.material.color = new Color(255, 255, 255, ((_clear == true) ? 0 : 255)); //�I�u�W�F�N�g�̓�����
            _blockColor.a = (_clear == true) ? 0 : 1;
            _through = (_clear == true) ? true : false;
        }
        else
        {
            //�ŏ��ɕ\������Ă����u���b�N�𔽓]
            //spriteRenderer.material.color = new Color(255, 255, 255, ((_clear == true) ? 255 : 0)); //�I�u�W�F�N�g�̓�����
            _blockColor.a = (_clear == true) ? 1 : 0;
            _through = (_clear == true) ? false : true;
        }
        spriteRenderer.material.color = _blockColor;
    }

    private void CheckThrough()
    {
        if (_through)
        {  
            //BoxCollider2D���O��
            boxCollider2.enabled = false;

            //this.tag = "Empty";
        }
        else
        {
            //BoxCollider2D��t����
            boxCollider2.enabled = true;

            //this.tag = "Ground";
        }
    }
}
