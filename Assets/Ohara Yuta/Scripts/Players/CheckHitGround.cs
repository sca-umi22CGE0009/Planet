using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHitGround : MonoBehaviour
{
    public bool _jumpFlag = false;
    public bool JumpFlag()
    {
        return _jumpFlag;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        //�n�ʂ��u���b�N�̏�ɗ�������W�����v���͂̎󂯕t�����s��
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("Switch"))
        {
            _jumpFlag = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //�n�ʂ��u���b�N�𗣂ꂽ��W�����v���͂̎󂯕t�������Ȃ�
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("Switch"))
        {
            _jumpFlag = false;
        }
    }
}
