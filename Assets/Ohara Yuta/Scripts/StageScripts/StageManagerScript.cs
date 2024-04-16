using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManagerScript : MonoBehaviour
{
    public static int _nowStage = 3;
    public int GetNowStageNumber()
    {
        return _nowStage;
    }

    GameObject _goal;
    GoalScript _goalScript;

    private bool changeEnd = true;

    [SerializeField] float _changeInterval = 2;

    // Start is called before the first frame update
    void Start()
    {
        _goal = GameObject.Find("Rocket");
        _goalScript = _goal.GetComponent<GoalScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_goalScript.GetStagelear() && changeEnd)
        {
            StartCoroutine(StageNumberChange());
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _nowStage = 3;
            SceneManager.LoadScene("TitleScene");
        }
    }

    IEnumerator StageNumberChange()
    {
        changeEnd = false;
        _nowStage++;
        yield return new WaitForSecondsRealtime(_changeInterval);
        changeEnd = true;

        if(8 < _nowStage) {
            _nowStage = 3;
        }
    }
}
