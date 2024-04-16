using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public bool _alive;

    private Rigidbody2D _rb;

    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 20;

    private float _velocityX = 0;

    [SerializeField] CheckHitGround _checkHitGround;
    private bool _jumpFlag = false;

    private BoxCollider2D _boxCol;

    [SerializeField] private float _changeTime = 2.0f;

    Animator animator;

    private Vector3 _deadPos;

    // Start is called before the first frame update
    void Start()
    {
        _alive = true;
        _rb = GetComponent<Rigidbody2D>();
        _boxCol = GetComponent<BoxCollider2D>();
        _boxCol.enabled = true;

        this.gameObject.tag = "Player";

        animator = GetComponent<Animator>();
        animator.SetInteger("move", 0);
    }

    // Update is called once per frame
    void Update()
    {
        _velocityX = 0;

        animator.SetInteger("move", 0);

        if (_alive)
        {
            if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
            {
                _velocityX = _speed;
                animator.SetInteger("move", 1);
            }
            else if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
            {
                _velocityX = -_speed;
                animator.SetInteger("move", -1);
            }

            if (Input.GetKeyDown("up") || Input.GetKeyDown(KeyCode.Space))
            {
                if (_checkHitGround.JumpFlag())
                {
                    _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
                    animator.SetBool("jump", true);
                }
            }

            Fall();
        }
    }

    private void Fall()
    {
        if (_alive)
        {
            if (transform.position.y <= -10)
            {
                Dead();
            }
        }
    }

    private void FixedUpdate()
    {
        if (_alive)
        {
            _rb.velocity = new Vector2(_velocityX, _rb.velocity.y);
        }
        else
        {
            transform.localPosition = _deadPos;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //地面かブロックの上に立ったらジャンプ入力の受け付けを行う
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("Switch"))
        {
            if (_checkHitGround.JumpFlag())
            {
                _jumpFlag = true;
                animator.SetBool("jump", false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //地面かブロックを離れたらジャンプ入力の受け付けをしない
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("Switch"))
        {
            _jumpFlag = false;
            animator.SetBool("jump", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_alive)
        {
            //Obstacle : 障害物　プレイヤーが障害物(罠)に当たったときに死亡判定を行う
            //Enemy : 敵　プレイヤーが敵(蛇、鷹)に当たったときに死亡判定を行う
            if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy"))
            {
                Dead();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy"))
        {
            Dead();
        }
    }

    private void Dead()
    {
        _alive = false;
        _boxCol.enabled = false;
        _deadPos = transform.localPosition;
        animator.SetTrigger("dead");
        StartCoroutine(DeadTime());
    }

    IEnumerator DeadTime()
    {
        this.gameObject.tag = "PlayerDead";
        _rb.gravityScale = 0;
        yield return new WaitForSeconds(_changeTime); //1秒待つ
        _rb.gravityScale = 100;
        yield return new WaitForSeconds(_changeTime); //1秒待つ
        _alive = true;
        SceneManager.LoadScene("RemainingLivesCheck");
    }

    public bool GetPlayerDead()
    {
        return _alive;
    }
}
