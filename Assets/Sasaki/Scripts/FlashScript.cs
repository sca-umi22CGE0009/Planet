using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class FlashScript : MonoBehaviour
{
    [SerializeField, Header("�_�Ŏ����S�̂̎���")] private float totalTime = 1.0f;
    [SerializeField, Header("�_�Ŏ���")] private float flashTime = 0.5f; //�_�Ŏ���
    float resetTime; //���Z�b�g����܂ł̕b��

    private Renderer flashBlock; //�I�u�W�F�N�g
    private BoxCollider2D box;

    void Start()
    {
        flashBlock = GetComponent<Renderer>();
        box = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        resetTime += Time.deltaTime;

        //Memo
        //flash�̒l�܂�time����������0�ɖ߂�
        float repeatValue = Mathf.Repeat(resetTime, totalTime);

        //Memo
        //enabled: �R���|�[�l���g���A�N�e�B�u�A��A�N�e�B�u�ɂ��邽�߂Ɏg�p
        //repeatValue��0.5���傫���Ȃ�����true
        flashBlock.enabled = repeatValue >= flashTime;

        box.enabled = repeatValue >= flashTime;
    }
}
