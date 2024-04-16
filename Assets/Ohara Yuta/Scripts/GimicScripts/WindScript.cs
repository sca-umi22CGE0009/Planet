using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
	// x�������ɉ����镗�̗�
	public float windX = 0f;
	// y�������ɉ����镗�̗�
	public float windY = 0f;

	/// <summary>
	/// �g���K�[�͈̔͂ɓ����Ă���Ԃ����Ǝ��s�����
	/// </summary>
	/// <param name="other"></param>
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			//// �������������rigidbody�R���|�[�l���g���擾
			//Rigidbody2D otherRigidbody = collision.GetComponent<Rigidbody2D>();

			//// rigidbody��null�ł͂Ȃ��ꍇ�i�����GameObject��rigidbody���t���Ă���ꍇ�j
			//if (otherRigidbody != null)
			//{
			//	// �����rigidbody�ɗ͂�������
			//	otherRigidbody.AddForce(new Vector2(windX, windY), ForceMode2D.Impulse);
			//}

			collision.transform.Translate(windX, windY, 0);
		}
	}
}
