using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    [Header("x‚Ì”ÍˆÍ")]
    [SerializeField]
    private float range_x = 5;
    [Header("y‚Ì”ÍˆÍ")]
    [SerializeField]
    private float range_y = 0;
    [Header("‰•œ‚·‚éŠÔ")]
    [SerializeField]
    private float time = 1;
    private Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(pos.x + Mathf.Sin((Time.time) / time) * range_x, 
                                                    pos.y + Mathf.Cos((Time.time) / time) * range_y);
    }
}
