using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBarMove : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 0.2f;

    [SerializeField] private bool _onFrip = true;
    [SerializeField] private float _frip = 1.0f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate() //1•b‚É50ƒtƒŒ[ƒ€ŒÅ’è
    {
        transform.Rotate(0, 0, _rotateSpeed * _frip); //‰E‰ñ“]
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("Obstacle"))
        {
            if (_onFrip)
            {
                _frip *= -1.0f; //‹t‰ñ“]
            }
        }
    }
}
