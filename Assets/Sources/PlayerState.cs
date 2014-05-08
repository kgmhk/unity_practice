using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {
	public Transform cameraPosistion = null;
	private Vector3 MyPosition = Vector3.zero;
	private int goldCount = 0;

	IEnumerator DieProcess(float shakeTime, float shakeSense)
	{
		float deltaTime = 0.0f;
		while (deltaTime < shakeTime)
		{
			deltaTime += Time.deltaTime;

			cameraPosistion.position = MyPosition;

			Vector3 pos = Vector3.zero;
			pos.x = Random.Range(-shakeSense, shakeSense);
			pos.y = Random.Range(-shakeSense, shakeSense);
			cameraPosistion.position += pos;

			yield return new WaitForEndOfFrame();
		}
		cameraPosistion.transform.position = MyPosition;
	}

	void OnTriggerEnter2D(Collider2D other){

		//충돌 한other 의게임오브젝트 의레이 어값 을얻 어온 다.
		//그것 을통 해gold,monster,meteorite 를구 분한  다.
		int layerIndex = other.gameObject.layer;

		//LayerMask 는 Gold레이어 에대 한인덱 스값 을넘 겨준 다.
		if(layerIndex == LayerMask.NameToLayer("Gold"))
		{
			goldCount++;
			print ("goldCount : " + goldCount); 
			Destroy(other.gameObject);
		}
		else if(layerIndex == LayerMask.NameToLayer("Monster"))
		{
			StartCoroutine(DieProcess (0.5f, 0.1f));
		}
		else if(layerIndex == LayerMask.NameToLayer("Meteorite"))
		{
			StartCoroutine(DieProcess (0.5f, 0.1f));
		}



	}

	void Start () {
		MyPosition = cameraPosistion.position;
	}
	
	void Update () {
	
	}
}
