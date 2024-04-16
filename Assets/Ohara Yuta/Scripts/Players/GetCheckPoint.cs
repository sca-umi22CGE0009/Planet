using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCheckPoint : MonoBehaviour
{
    public GameObject _respawnPointObject;

    private Vector3 _respawnPoint;
    private Vector3 _startPoint;
    private static bool _getCheckPoint = false;

    // Start is called before the first frame update
    void Start()
    {
        _startPoint = transform.position;
        _respawnPoint = _respawnPointObject.transform.position;

        if (!_getCheckPoint)
        {
            transform.position = _startPoint;
        }
        else
        {
            transform.position = _respawnPoint;
        }
        Debug.Log(_getCheckPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //��蒼�����ߒ��Ԓn�_��񃊃Z�b�g
            _getCheckPoint = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            //���Ԓn�_�Q�b�g
            _getCheckPoint = true;
        }
        if (collision.gameObject.CompareTag("Rocket"))
        {
            //�X�e�[�W�N���A�̂��ߒ��Ԓn�_��񃊃Z�b�g
            _getCheckPoint = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rocket"))
        {
            //�X�e�[�W�N���A�̂��ߒ��Ԓn�_��񃊃Z�b�g
            _getCheckPoint = false;
        }
    }
}
