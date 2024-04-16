using UnityEngine;

public class PSwitch : MonoBehaviour
{
    public string targetTag = "SwitchBlock"; // 消えるブロックのタグ
    public GameObject pSwitchObject; // Pスイッチオブジェクト

    private bool isSwitchOn = false; // スイッチがオンかどうかのフラグ

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isSwitchOn && (collision.CompareTag("Player") || collision.CompareTag("PSwitch")))
        {
            isSwitchOn = true;

            // 指定したタグを持つオブジェクトを検索し、非アクティブにする
            GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);
            foreach (GameObject obj in targetObjects)
            {
                obj.SetActive(false);
            }

            // Pスイッチオブジェクトも非アクティブにする
            pSwitchObject.SetActive(false);
        }
    }
}
