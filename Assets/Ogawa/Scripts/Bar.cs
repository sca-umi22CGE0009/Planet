using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bar : MonoBehaviour
{
    /// <summary>
    /// ----���ӓ_----
    /// rigidbody2d��gravityscale���O�ɂ��邱��
    /// �f�o�C�X�̖��ōŏ��̉���̓��삪�u�Ԉړ��̂悤�ȋ����ɂȂ��Ă���B
    /// �v����
    /// </summary>
    public float DownSpeed;
    public float UpSpeed;
    private Vector2 startPos;
    private Vector2 targetPos;
    private bool isMovingUp = false;
    private bool isStop = false;
    private float stopDuration = 0.5f;
    private float stopTimer = 0.0f;



    void Start()
    {
        startPos = transform.position;
        targetPos = new Vector2(startPos.x, 5.0f);
    }



    void Update()
    {
        Vector2 pos = transform.position;



        if (!isStop)
        {
            if (!isMovingUp)
            {
                pos.y -= Time.deltaTime * DownSpeed;
                transform.position = pos;



                if (pos.y < 0)
                {
                    pos.y = 0;
                    isMovingUp = true;
                    isStop = true;
                    stopTimer = 0.0f;
                    StartCoroutine(StopMovement(stopDuration)); // �㏸�^���̒�~���J�n
                }
            }
            else
            {
                if (pos.y < targetPos.y)
                {
                    pos.y += Time.deltaTime * UpSpeed;
                    transform.position = pos;
                }
                else
                {
                    pos.y = targetPos.y; // �ڕW�ʒu�܂œ��B������ʒu���C������
                    isMovingUp = false;
                    isStop = true;
                    stopTimer = 0.0f;
                    StartCoroutine(StopMovement(stopDuration)); // ���~�^���̒�~���J�n
                }
            }
        }
    }



    IEnumerator StopMovement(float duration)
    {
        yield return new WaitForSeconds(duration);
        isStop = false;
    }
}
