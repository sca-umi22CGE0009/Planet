using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltconveyorMone : MonoBehaviour
{
    [SerializeField] float _conveyorSpeed = 0.01f;
    [SerializeField] bool _derectionRight = false;
    private float _goRight = 1;

    [SerializeField] bool _derectionFlip = false;
    [SerializeField] private float _flipInterval = 1.0f;
    private float _countdownTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        _countdownTime = _flipInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (_derectionFlip)
        {
            Flip();
        }

        if (_derectionRight)
        {
            _goRight = 1;
        }
        else
        {
            _goRight = -1;
        }
    }

    private void Flip()
    {
        _countdownTime -= Time.deltaTime;

        if (_countdownTime <= 0)
        {
            _countdownTime = _flipInterval;
            _derectionRight = !_derectionRight;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.Translate(_conveyorSpeed * _goRight, 0,0);
        }
    }
}
