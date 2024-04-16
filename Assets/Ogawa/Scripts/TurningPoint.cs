using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningPoint : MonoBehaviour
{
    public GameObject respawnPointObject;

    private Transform respawnPoint;

    private void Start()
    {
        respawnPoint = respawnPointObject.transform;
    }

    private void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime;
        //transform.Translate(movement);

        // キャラクターがセーブポイントを通過したかチェック
        if (transform.position == respawnPoint.position)
        {
            SaveManager.SetRespawnPoint(respawnPoint.position);
        }

        // キャラクターが画面外に出たらリスポーン
        //if (!IsInScreenBounds(transform.position))
        //{
        //    Vector3 respawnPosition = SaveManager.GetRespawnPoint();
        //    transform.position = respawnPosition;
        //}
    }

    //private bool IsInScreenBounds(Vector3 position)
    //{
    //    Vector3 screenPosition = Camera.main.WorldToScreenPoint(position);
    //    return screenPosition.x > 0 && screenPosition.x < Screen.width && screenPosition.y > 0 && screenPosition.y < Screen.height;
    //}
}

public class SaveManager
{
    private static Vector3 respawnPoint = Vector3.zero;

    public static void SetRespawnPoint(Vector3 position)
    {
        respawnPoint = position;
    }

    public static Vector3 GetRespawnPoint()
    {
        return respawnPoint;
    }
}