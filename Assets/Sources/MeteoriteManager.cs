using UnityEngine;
using System.Collections;

public class MeteoriteManager : MonoBehaviour {
	public GameObject meteoriteEnemy = null;
	public GameObject alarmEnemy = null;
	public GameObject tail = null;
	public Transform alarmPosition = null;

	void Start () {
		StartCoroutine(Factory());

	}

	IEnumerator Factory(){
		float time = Random.Range(2.0f, 3.0f);
		yield return new WaitForSeconds(time);


		GameObject alarmObj = Instantiate(alarmEnemy) as GameObject;
		alarmObj.transform.position = alarmPosition.position;

		//animation 의길이 를구한.다
		float length = alarmObj.animation["Alarm"].length;
		//animation 의길 이만 큼대 기
		yield return new WaitForSeconds(length);


		Destroy(alarmObj);

		GameObject meteoObj = Instantiate(meteoriteEnemy) as GameObject;
		meteoObj.transform.position = this.transform.position;

		GameObject tailObj = Instantiate(tail) as GameObject;
		tailObj.transform.position = this.transform.position;
		tailObj.renderer.sortingLayerName = "Tail";

		tailObj.transform.parent = meteoObj.transform;

		StartCoroutine(Factory());
	}
	
}
