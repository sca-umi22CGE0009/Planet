using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField]
    private float time;
    void Start()
    {
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine("CoolTime");
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name == "Player")
    //        {
    //        StartCoroutine("CoolTime");
    //    }
    //}
    IEnumerator CoolTime()
    {
        //2�b�o������
        yield return new WaitForSeconds(time);
        //������쓮����
        this.gameObject.SetActive(false);
    }
}
