using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallGround : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] float _fallSpeed = 5; //�����Ă���X�s�[�h
    [SerializeField] float _groundFallInterval = 0.5f; //�����Ă���X�s�[�h
    private bool _fall = false;
    private Vector3 _startPos;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        _rb.constraints = RigidbodyConstraints2D.FreezeAll;
        _startPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(GroundFallInterval());
        }
    }

    IEnumerator GroundFallInterval()
    {
        yield return new WaitForSeconds(_groundFallInterval);

        //��x�S�Ă��������Ă���
        _rb.constraints = RigidbodyConstraints2D.None;
        //FreezePositionY�ȊO��t���Ȃ���
        _rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        _rb.gravityScale = _fallSpeed;
    }
}
