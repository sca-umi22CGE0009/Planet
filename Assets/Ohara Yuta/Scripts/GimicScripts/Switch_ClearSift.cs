using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_ClearSift : MonoBehaviour
{
    [SerializeField] public static bool _clear = true;
    private bool _switchOkey = true;

    [SerializeField, Header("「0」で常に表示")] private float _checkTime = 5.0f;
    private bool _timeLimit = true;

    public bool GetClear() { return _clear; }

    // Start is called before the first frame update
    void Start()
    {
        //死亡時に反転を戻す
        _clear = true;

        //_checkTimeが0ならスイッチが押されたらその後ずっと表示。再び押すと消える。
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
