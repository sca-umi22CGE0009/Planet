using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeOverGimic : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] float _fallSpeed = 5; //落ちてくるスピード
    
    [SerializeField] private Text _timeText;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (float.Parse(_timeText.text) <= 0)
        {
            _rb.gravityScale = _fallSpeed;
        }
    }
}
