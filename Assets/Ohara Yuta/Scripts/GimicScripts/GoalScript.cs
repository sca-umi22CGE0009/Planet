using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    public bool _stageClear;
    public bool GetStagelear()
    {
        return _stageClear;
    }

    private int _maxStageNumber = 6;

    private string _sceneName;

    private static int _nowStageNumber = 1;

    [SerializeField] float _changeInterval = 2;

    // Start is called before the first frame update
    void Start()
    {
        _sceneName = "StageChange";
        _stageClear = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_stageClear)
        {
            StartCoroutine(ChangeStage());
        }
    }

    IEnumerator ChangeStage()
    {
        _stageClear = true;
        _nowStageNumber++;
        if (_maxStageNumber < _nowStageNumber)
        {
            _nowStageNumber = 1;
            _sceneName = "EndCard";
        }

        Debug.Log(_nowStageNumber);

        yield return new WaitForSecondsRealtime(_changeInterval);
        _stageClear = false;
        SceneManager.LoadScene(_sceneName);
    }
}
