using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ƒGƒ“ƒ^[‚ğ‰Ÿ‚µ‚½‚ç
        if (Input.GetKey(KeyCode.Return))
        {
            //"StageSelectScene"‚É‘JˆÚ‚·‚é
            SceneManager.LoadScene("TitleScene");
        }

    }
}
