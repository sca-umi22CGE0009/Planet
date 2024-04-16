using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
	// x軸方向に加える風の力
	public float windX = 0f;
	// y軸方向に加える風の力
	public float windY = 0f;

	/// <summary>
	/// トリガーの範囲に入っている間ずっと実行される
	/// </summary>
	/// <param name="other"></param>
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			//// 当たった相手のrigidbodyコンポーネントを取得
			//Rigidbody2D otherRigidbody = collision.GetComponent<Rigidbody2D>();

			//// rigidbodyがnullではない場合（相手のGameObjectにrigidbodyが付いている場合）
			//if (otherRigidbody != null)
			//{
			//	// 相手のrigidbodyに力を加える
			//	otherRigidbody.AddForce(new Vector2(windX, windY), ForceMode2D.Impulse);
			//}

			collision.transform.Translate(windX, windY, 0);
		}
	}
}
