using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_ClearSift : MonoBehaviour
{
    [SerializeField] public static bool _clear = true;
    private bool _switchOkey = true;

    [SerializeField, Header("�u0�v�ŏ�ɕ\��")] private float _checkTime = 5.0f;
    private bool _timeLimit = true;

    public bool GetClear() { return _clear; }

    // Start is called before the first frame update
    void Start()
    {
        //���S���ɔ��]��߂�
        _clear = true;

        //_checkTime��0�Ȃ�X�C�b�`�������ꂽ�炻�̌ジ���ƕ\���B�Ăщ����Ə�����B
        _timeLimit = (_checkTime == 0) ? false : true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerHead") && _switchOkey)
        {
            if (_clear)
            {
                _clear = false;
                if (_timeLimit)
                {
                    StartCoroutine(TimeLimit());
                }
            }
            else
            {
                _clear = true;
                if (_timeLimit)
                {
                    StartCoroutine(TimeLimit());
                }
            }
        }
    }

    IEnumerator TimeLimit()
    {
        _switchOkey = false;
        yield return new WaitForSecondsRealtime(_checkTime);
        _switchOkey = true;
        _clear = !_clear;
    }
}
