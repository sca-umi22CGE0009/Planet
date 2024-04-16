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

    [SerializeField] float _fallSpeed = 5; //�����Ă���X�s�[�h
    [SerializeField] float _rayLength = 10.0f; //rey�̒���

    [SerializeField] float _rayPos = 4;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _objectWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;�@//�����̎擾
        _objectHeight = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;�@//�c���̎擾

        //Ray�̌��_
        origin = new Vector2(transform.position.x - _objectWidth / _rayPos, transform.position.y - _objectHeight / 1.8f);
        //Ray�̕���
        direction = new Vector2(0, -_rayLength);
    }

    // Update is called once per frame
    void Update()
    {
        //Ray�𐶐��@Physics2D.Raycast(Ray�̌��_, Ray�̕���)
        RaycastHit2D hit = Physics2D.Raycast(origin, direction);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player") || hit.collider.gameObject.CompareTag("PlayerHead"))
            {
                Debug.DrawRay(origin, direction, Color.green, _rayLength); //Scene���Ray������
                _rb.gravityScale = _fallSpeed;
            }
            else
            {
                Debug.DrawRay(origin, direction, Color.red, _rayLength);//Scene���Ray������
            }
        }
        else
        {
            Debug.DrawRay(origin, direction, Color.red, _rayLength);//Scene���Ray������
        }
    }
}
