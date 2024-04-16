using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMove : MonoBehaviour
{
    [SerializeField] private float _speedMove = 0.1f;
    Vector3 cameraRect;

    //private Vector2 _ResetPosition;
    //[SerializeField] private float _RPosX = 18f;
    //[SerializeField] private float _limitX = -10.235f;
    // Start is called before the first frame update
    void Start()
    {
        //_ResetPosition = new Vector2(_RPosX, 0);
        cameraRect = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
    }

    void Update()
    {
        BackGroundMove();
    }

    private void FixedUpdate()
    {
        //transform.position = new Vector2(transform.position.x - _speedMove, 0);

        //if (transform.position.x <= _limitX)
        //{
        //    transform.position = _ResetPosition;
        //}
    }
    void BackGroundMove()
    {
        //x軸にスクロール
        transform.Translate(Vector3.right * -_speedMove * Time.deltaTime);
        //カメラの左端から完全に出たら、右端に瞬間移動
        if (transform.position.x < (cameraRect.x - Camera.main.transform.position.x) * 2)
        {
            transform.position = new Vector3((Camera.main.transform.position.x - cameraRect.x) * 2 , transform.position.y);
        }
    }
}
