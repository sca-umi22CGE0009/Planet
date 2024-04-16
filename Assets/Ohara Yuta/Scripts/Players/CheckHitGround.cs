using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHitGround : MonoBehaviour
{
    public bool _jumpFlag = false;
    public bool JumpFlag()
    {
        return _jumpFlag;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        //地面かブロックの上に立ったらジャンプ入力の受け付けを行う
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("Switch"))
        {
            _jumpFlag = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //地面かブロックを離れたらジャンプ入力の受け付けをしない
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("Switch"))
        {
            _jumpFlag = false;
        }
    }
}
