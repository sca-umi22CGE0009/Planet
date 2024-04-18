using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class BoundScript : MonoBehaviour
{
    [SerializeField, Header("プレイヤーのRigidbody2D")] private Rigidbody2D player;

    [SerializeField, Header("バウンドの値")] private float bound = 13.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") { 
            player.AddForce(Vector2.up * bound, ForceMode2D.Impulse);
        }
    }
}
