using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D player;

    //[SerializeField]
    //private Rigidbody2D enemy;

    [SerializeField]
    private float bound = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player") { 
            player.AddForce(Vector2.up * bound, ForceMode2D.Impulse);
        }
        //if (collision.gameObject.tag == "Enemy")
        //{
        //    enemy.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        //}
    }
}
