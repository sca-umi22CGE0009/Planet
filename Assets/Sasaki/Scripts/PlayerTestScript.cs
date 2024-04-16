using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestScript : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // D�L�[�i�E�ړ��j
        if (Input.GetKey(KeyCode.D))
        {
            rb2D.velocity = transform.right * speed;
        }

        // A�L�[�i���ړ��j
        if (Input.GetKey(KeyCode.A))
        {
            rb2D.velocity = -transform.right * speed;
        }
    }
}
