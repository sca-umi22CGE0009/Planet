using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNextStageIn : MonoBehaviour
{
    private bool _nextStageIn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CameraScroll());
        }
    }

    IEnumerator CameraScroll()
    {
        _nextStageIn = true;
        yield return new WaitForSeconds(1.0f);
        _nextStageIn = false;
    }
}
