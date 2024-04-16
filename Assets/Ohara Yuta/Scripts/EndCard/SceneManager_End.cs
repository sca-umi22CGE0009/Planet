using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_End : MonoBehaviour
{
    private bool _sceneChange = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitSceneChange());
    }

    IEnumerator WaitSceneChange()
    {
        yield return new WaitForSeconds(30);
        _sceneChange = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_sceneChange && Input.anyKeyDown)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
