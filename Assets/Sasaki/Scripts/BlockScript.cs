using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class BlockScript : MonoBehaviour
{
    [SerializeField, Header("�v���C���[������Ă�������锻�������܂ł̎���")] private float playerJadgmentTime = 1.0f;
    private float timeSave;
    [SerializeField, Header("�v���C���[������Ă��������܂ł̎���")] private float moveTime = 0.5f;

    bool inCheck; //�v���C���[���G��Ă��邩

    void Start()
    {
        inCheck = false;
        timeSave = playerJadgmentTime;
    }

    void Update()
    {
        //�v���C���[���G��Ă���Ƃ�
        if (inCheck)
        {
            timeSave -= Time.deltaTime;
            Debug.Log(timeSave);

            //Debug.Log(timeSave);
            //�v���C���[��playerfadgmentTime�b����Ă�����
            if (timeSave < 0)
            {
                StartCoroutine(CoolTime());
            }
        }
        else
        {
            //������
            timeSave = playerJadgmentTime;
        }

    }

    //�v���C���[���G�ꂽ��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inCheck = true;
        }
    }
    //�G��Ă��Ȃ��Ƃ�
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inCheck = false;
        }
    }

    //������܂ł̎��Ԕ���
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(moveTime);
        this.gameObject.SetActive(false);
    }
}
