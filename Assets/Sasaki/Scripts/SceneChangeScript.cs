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
            //エンターを押したら
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //"StageSelectScene"に遷移する
                SceneManager.LoadScene("TitleScene");
            }
        }
    }
    void TitleSceneChange()
    {
        //タイトルシーンだったら
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            time -= Time.deltaTime;
            //エンターを押したら
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //"StageSelectScene"に遷移する
                SceneManager.LoadScene("RemainingLivesCheck");
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //"StageSelectScene"に遷移する
                Application.Quit();
            }
            if (time <= 0)
            {
                SceneManager.LoadScene("StoryScene");
            }
        }
    }
}
