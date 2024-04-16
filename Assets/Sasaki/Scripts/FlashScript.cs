using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashScript : MonoBehaviour
{
    [SerializeField]
    private Renderer flashBlock; //�I�u�W�F�N�g
    [SerializeField]
    private float flash = 1.0f; //�_�Ŏ���
    private float time; //�b��
    private BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        //flash�̒l�܂�time����������0�ɖ߂�
        float repeatValue = Mathf.Repeat((float)time, flash);

        //repeatValue��0.5���傫���Ȃ�����true
        flashBlock.enabled = repeatValue >= flash * 0.5;

        //box.isTrigger = repeatValue <= flash * 0.5;

        //this.tag = (repeatValue <= flash * 0.5) ? "Untagged" : "Ground";

        box.enabled = repeatValue >= flash * 0.5;
    }
}
