using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private float _changeTime = 2.0f;
    GameObject _stageManager;
    [SerializeField] StageManagerScript _stageManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoMainScean());
    }

    IEnumerator GoMainScean()
    {
        yield return new WaitForSeconds(_changeTime);
        SceneManager.LoadScene(_stageManagerScript.GetNowStageNumber());
    }
}
