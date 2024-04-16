using UnityEngine;

public class PSwitch : MonoBehaviour
{
    public string targetTag = "SwitchBlock"; // ������u���b�N�̃^�O
    public GameObject pSwitchObject; // P�X�C�b�`�I�u�W�F�N�g

    private bool isSwitchOn = false; // �X�C�b�`���I�����ǂ����̃t���O

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isSwitchOn && (collision.CompareTag("Player") || collision.CompareTag("PSwitch")))
        {
            isSwitchOn = true;

            // �w�肵���^�O�����I�u�W�F�N�g���������A��A�N�e�B�u�ɂ���
            GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);
            foreach (GameObject obj in targetObjects)
            {
                obj.SetActive(false);
            }

            // P�X�C�b�`�I�u�W�F�N�g����A�N�e�B�u�ɂ���
            pSwitchObject.SetActive(false);
        }
    }
}
