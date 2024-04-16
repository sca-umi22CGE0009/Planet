using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCeiling : MonoBehaviour
{
    private Rigidbody2D _rb;
    Vector2 origin;
    Vector2 direction;

    private float _objectWidth;
    private float _objectHeight;

    [SerializeField] float _fallSpeed = 5; //落ちてくるスピード
    [SerializeField] float _rayLength = 10.0f; //reyの長さ

    [SerializeField] float _rayPos = 4;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _objectWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;　//横幅の取得
        _objectHeight = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;　//縦幅の取得

        //Rayの原点
        origin = new Vector2(transform.position.x - _objectWidth / _rayPos, transform.position.y - _objectHeight / 1.8f);
        //Rayの方向
        direction = new Vector2(0, -_rayLength);
    }

    // Update is called once per frame
    void Update()
    {
        //Rayを生成　Physics2D.Raycast(Rayの原点, Rayの方向)
        RaycastHit2D hit = Physics2D.Raycast(origin, direction);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player") || hit.collider.gameObject.CompareTag("PlayerHead"))
            {
                Debug.DrawRay(origin, direction, Color.green, _rayLength); //Scene上でRayを可視化
                _rb.gravityScale = _fallSpeed;
            }
            else
            {
                Debug.DrawRay(origin, direction, Color.red, _rayLength);//Scene上でRayを可視化
            }
        }
        else
        {
            Debug.DrawRay(origin, direction, Color.red, _rayLength);//Scene上でRayを可視化
        }
    }
}
