using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class BgMove : MonoBehaviour
{
    [SerializeField,Header("背景を動かす速度")] private float speedMove = 0.1f;
    Vector3 cameraRect;

    void Start()
    {
        cameraRect = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
    }

    void Update()
    {
        BackGroundMove();
    }
    //背景を動かす
    void BackGroundMove()
    {
        transform.Translate(Vector3.right * -speedMove * Time.deltaTime);

        //カメラの左端から完全に出たら、右端に瞬間移動
        if (transform.position.x < (cameraRect.x - Camera.main.transform.position.x) * 2)
        {
            transform.position = 
                new Vector3((Camera.main.transform.position.x - cameraRect.x) * 2 , transform.position.y);
        }
    }
}