using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroller : MonoBehaviour
{
    private GameObject _playeObjs;
    private Vector3 _playePos;
    [SerializeField] Camera _playerViewCamera;

    private bool _scrollOn = false;
    [SerializeField] float _scrollSpeed = 0.1f;
    private Rect _rect = new Rect(0, 0, 1.05f, 1);

    [SerializeField] GameObject _backGround;
    [SerializeField] private float _backgroundScrollSpeed = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        _playeObjs = GameObject.Find("Player");
        _playePos = _playeObjs.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Viepoint座標 : スクリーン座標を0～1で正規化したもの。
        //左下が(0, 0)、右上が(1, 1)中心が(0.5, 0.5)。
        //いずれかの座標が0以下、1以上で画面外。
        //var viewpoint = _playerViewCamera.WorldToViewportPoint(_playeObjs._playePos);

        //if (!(_rect.Contains(viewpoint))) //Contains : 指定の文字列や数字、要素が含まれているか
        //{
        //}
        _playePos = _playeObjs.transform.position;
    }

    private void LateUpdate()
    {
        if (0 <= _playePos.x)
        {
            this.transform.position = new Vector3(_playePos.x, transform.position.y, transform.position.z);
            _backGround.transform.position = new Vector3(_playePos.x * _backgroundScrollSpeed, transform.position.y, transform.position.z);
        }
    }
}
