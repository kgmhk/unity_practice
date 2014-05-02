using UnityEngine;
using System.Collections;

public class MissileProcess : MonoBehaviour {

	public GameObject empty = null;
	public Transform missilePos= null;
	private float interval = 0.0f;
	private float intervalMax = 0.1f;

	void Update () {
		interval += Time.deltaTime;	
		if(interval > intervalMax)
		{
			interval = 0.0f;
			//as : 캐스  팅 현 재 empty 는object인 데gameobject 로변경하 는것
			GameObject obj = Instantiate(empty) as GameObject;
			//this 는플레이 어의위 치
			obj.transform.position = missilePos.position;		
			//print ("interval !!");
		}
	}
}
