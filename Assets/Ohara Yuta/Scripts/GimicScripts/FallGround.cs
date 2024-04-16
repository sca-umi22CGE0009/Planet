using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallGround : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] float _fallSpeed = 5; //落ちてくるスピード
    [SerializeField] float _groundFallInterval = 0.5f; //落ちてくるスピード
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

        //一度全てを解除してから
        _rb.constraints = RigidbodyConstraints2D.None;
        //FreezePositionY以外を付けなおす
        _rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        _rb.gravityScale = _fallSpeed;
    }
}
