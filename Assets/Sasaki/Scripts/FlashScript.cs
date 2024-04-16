using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashScript : MonoBehaviour
{
    [SerializeField]
    private Renderer flashBlock; //オブジェクト
    [SerializeField]
    private float flash = 1.0f; //点滅周期
    private float time; //秒数
    private BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        //flashの値までtimeが増えたら0に戻す
        float repeatValue = Mathf.Repeat((float)time, flash);

        //repeatValueが0.5より大きくなったらtrue
        flashBlock.enabled = repeatValue >= flash * 0.5;

        //box.isTrigger = repeatValue <= flash * 0.5;

        //this.tag = (repeatValue <= flash * 0.5) ? "Untagged" : "Ground";

        box.enabled = repeatValue >= flash * 0.5;
    }
}
