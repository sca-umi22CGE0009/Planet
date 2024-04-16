using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryText : MonoBehaviour
{
    [SerializeField,Header("�X�g�[���e�L�X�g")]
    private string[] texts;
    [SerializeField, Header("1�����̕\���̑��x")]
    private float textMove;
    float textTime;
    [SerializeField, Header("1�s�̕\���̑��x")]
    private float textNumTime = 0.1f;
    float time;

    int textNum;
    string storyText;
    int textCharNum;
    bool chack = true;
    bool tmp = true;
    // Start is called before the first frame update
    void Start()
    {
        textNum = 0;
        textCharNum = 0;
        textTime = textMove;
        time = textNumTime;
    }

    // Update is called once per frame
    void Update()
    {
        StoryTextMove();
    }
    void StoryTextMove()
    {
        textTime -= Time.deltaTime;
        //textTime��0�ɂȂ�����
        if (textTime <= 0)
        {
            //������̍Ō�̕�������Ȃ����
            if (textCharNum != texts[textNum].Length)
            {
                //storyText��textNum�Ԗڂ̕������
                //textCharNum�Ԗڂ̕�����ǉ�����
                storyText += texts[textNum][textCharNum];
                //textCharNum��1�������₷
                textCharNum = textCharNum + 1;
                //���Ԃ̏�����
                textTime = textMove;
            }
            else
            {
                //�Ō��texts[]�Ŏ~�߂�
                if (textNum != texts.Length - 1)
                {
                    if (chack)
                    {
                        tmp = true;
                        textCharNum = 0;
                        //����������Ԃɕ\��
                        textNum = textNum + 1;
                    }
                }
            }
            //storyText��\��
            this.GetComponent<Text>().text = storyText;
            chack = false;
        }
        //������
        time -= Time.deltaTime;
        if (!chack && time <= 0)
        {
            //�Ō�̔z��ȊO
            if (tmp && textNum < texts.Length - 1)
            {
                //���s
                texts[textNum] += "\n\n";
                tmp = false;
                time = textNumTime;
            }
            chack = true;
        }
    }
}
