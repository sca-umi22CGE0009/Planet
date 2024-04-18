using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class BlockScript : MonoBehaviour
{
    [SerializeField, Header("ƒvƒŒƒCƒ„[‚ªæ‚Á‚Ä‚©‚çÁ‚¦‚é‚Ü‚Å‚ÌŠÔ")] private float moveTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(CoolTime());
        }
    }
    //Á‚¦‚é‚Ü‚Å‚ÌŠÔ”»’è
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(moveTime);
        this.gameObject.SetActive(false);
    }
}
