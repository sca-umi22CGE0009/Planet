using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMove : MonoBehaviour
{
    [SerializeField] private GameObject _images;

    [SerializeField] private SpriteRenderer _sr;

    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 0);
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 255);
        }
    }
}
