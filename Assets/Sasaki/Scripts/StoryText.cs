using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// u.sasaki
/// </summary>
public class StoryText : MonoBehaviour
{
    [SerializeField,Header("ストーリテキスト")] private string[] texts;
    [SerializeField, Header("1文字の表示の速度")] private float textMove;
    float textTime;
    [SerializeField, Header("1行の表示の速度")] private float textNumTime = 0.1f;
    float time;

    int textNum;
    string storyText;
    int textCharNum;
    bool chack;
    bool tmp;


    void Start()
    {
        textNum = 0;
        textCharNum = 0;
        textTime = textMove;
        time = textNumTime;

        chack = true;
        tmp = true;
    }

    void Update()
    {
        StoryTextMove();

    }

    void StoryTextMove()
    {
        textTime -= Time.deltaTime;
        //textTimeが0以下になったら
        if (textTime <= 0)
        {
            //文字列の最後の文字じゃなければ
            if (textCharNum != texts[textNum].Length)
            {
                //Memo
                //storyTextにtextNum番目の文字列の
                //textCharNum番目の文字を追加する
                storyText += texts[textNum][textCharNum];
                textCharNum = textCharNum + 1;

                //時間の初期化
                textTime = textMove;
            }
            else
            {
                //最後のtexts[]で止める
                if (textNum != texts.Length - 1)
                {
                    if (chack)
                    {
                        tmp = true;
                        textCharNum = 0;
                        //文字列を順番に表示
                        textNum = textNum + 1;
                    }
                }
            }
            //storyTextを表示
            this.GetComponent<Text>().text = storyText;
            chack = false;
        }

        //文字列
        time -= Time.deltaTime;
        if (!chack && time <= 0)
        {
            //最後の配列以外
            if (tmp && textNum < texts.Length - 1)
            {
                //改行
                texts[textNum] += "\n\n";
                tmp = false;
                time = textNumTime;
            }
            chack = true;
        }
    }
}
