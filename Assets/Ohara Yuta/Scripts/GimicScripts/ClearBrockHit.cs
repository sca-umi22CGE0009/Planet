using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBrockHit : MonoBehaviour
{
    private BoxCollider2D _boxCol;
    private SpriteRenderer _spriRend;

    //private float _clearBrockWidth;
    private float _clearBrockHeight;

    private GameObject _player;
    private float _playerHeight;

    // Start is called before the first frame update
    void Start()
    {
        _boxCol = GetComponent<BoxCollider2D>();
        _spriRend = GetComponent<SpriteRenderer>();

        //_clearBrockWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x; //横幅の取得
        _clearBrockHeight = gameObject.GetComponent<SpriteRenderer>().bounds.size.y; //縦幅の取得

        _spriRend.material.color = new Color32(255, 255, 255, 0); //ブロックを透明に

        _player = GameObject.Find("Player");
        _playerHeight = (_player.GetComponent<SpriteRenderer>().bounds.size.y / 4); //Playerの縦幅の半分を取得
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerHead"))
        {
            if (collision.transform.position.y + _playerHeight <= this.gameObject.transform.position.y - _clearBrockHeight / 2)
            {
                BlockDisplay();
            }
        }
    }

    private void BlockDisplay()
    {
        //ブロックの位置がプレイヤーより上なら判定
        this._boxCol.isTrigger = false;
        _spriRend.material.color = new Color32(255, 255, 255, 255); //ブロックの透明化を解除
        this.tag = "Block";
    }
}
