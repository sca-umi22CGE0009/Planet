using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{

    [SerializeField]
    float time = 15;

    void Update()
    {
        TitleSceneChange();
        StorySceneChange();
    }

    void StorySceneChange()
    {
        if(SceneManager.GetActiveScene().name == "StoryScene")
        {
            //�G���^�[����������
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //"StageSelectScene"�ɑJ�ڂ���
                SceneManager.LoadScene("TitleScene");
            }
        }
    }
    void TitleSceneChange()
    {
        //�^�C�g���V�[����������
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            time -= Time.deltaTime;
            //�G���^�[����������
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //"StageSelectScene"�ɑJ�ڂ���
                SceneManager.LoadScene("RemainingLivesCheck");
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //"StageSelectScene"�ɑJ�ڂ���
                Application.Quit();
            }
            if (time <= 0)
            {
                SceneManager.LoadScene("StoryScene");
            }
        }
    }
}
