using UnityEngine;
using System.Collections;

public class DestroyZone : MonoBehaviour {

	//충돌하 는순 간알려주 는함 수(Is Trigger 체 크 시)
	void OnTriggerEnter2D(Collider2D other)
	{
		//해 당게 임오브젝 트삭 제함 수
		Destroy(other.gameObject);
		//print ("OnTriggerEnter2D" + other.gameObject.name);

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		//print ("OnCollisonEnter2D");
	}

}
