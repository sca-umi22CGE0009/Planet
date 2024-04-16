using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField] private float _speedMove = 0.1f;
    private Vector2 _ResetPosition;
    [SerializeField]  private float _limitY = -10.235f;

    // Start is called before the first frame update
    void Start()
    {
        _ResetPosition = new Vector2(0, 10.235f);
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    private void FixedUpdate()
    {
        transform.position = new Vector2(0,transform.position.y - _speedMove);

        if (transform.position.y <= _limitY)
        {
            transform.position = _ResetPosition;
        }
    }
}
