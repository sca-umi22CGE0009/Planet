using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class BgMove : MonoBehaviour
{
    [SerializeField,Header("�w�i�𓮂������x")] private float speedMove = 0.1f;
    Vector3 cameraRect;

    void Start()
    {
        cameraRect = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
    }

    void Update()
    {
        BackGroundMove();
    }
    //�w�i�𓮂���
    void BackGroundMove()
    {
        transform.Translate(Vector3.right * -speedMove * Time.deltaTime);

        //�J�����̍��[���犮�S�ɏo����A�E�[�ɏu�Ԉړ�
        if (transform.position.x < (cameraRect.x - Camera.main.transform.position.x) * 2)
        {
            transform.position = 
                new Vector3((Camera.main.transform.position.x - cameraRect.x) * 2 , transform.position.y);
        }
    }
}