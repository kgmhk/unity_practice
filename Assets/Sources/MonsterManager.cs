using UnityEngine;
using System.Collections;


/* 몬스터 가일 정간격으 로생 성되도 하 는스크립 트
 *
*/

public class MonsterManager : MonoBehaviour {

	//GameObject : unity에 서만 든게 임오브젝트 의시 작주소 를가지 고있.다
	// enemy라 는이름 의게 임오브젝트 로해 당객체 의정보 를가지 고있  다. (현 재여기에서 는몬스터 에대 한정보 를가지 고있 다)
	public GameObject enemy = null;
	public GameObject fireEnemy = null;

	private float startx = -2.0f;   //몬스터들 의위 치값 을관리하 는변 
	private int count = 5;				//몬스터 의  수 


	void Start () {
		//StartCoroutine 을 통해 호출된다.
		StartCoroutine(Factory());
	}
	

	IEnumerator Factory()
	{

		//대 기시간 을랜덤함수 로이용하 여제작
		float time = Random.Range(3.0f, 5.0f);
		// 3.0 초만큼 대기하라. 3 초 대기 후 아래 루틴 실행
		yield return new WaitForSeconds(time);

		int random = Random.Range(0, 5);
		Monster[] otherMonster = new Monster[4]; 
		int monsterCount = 0;
		Monster fireMonster = null;
		for(int i=0; i< count; ++i)
		{
			if(i == random){
				GameObject obj = Instantiate(fireEnemy) as GameObject;
				obj.transform.position = new Vector2(startx, 3.5f);
				fireMonster = obj.GetComponent<Monster>();

			}
			else{
				GameObject obj = Instantiate(enemy) as GameObject;
				obj.transform.position = new Vector2(startx, 3.5f);

				otherMonster[monsterCount] = obj.GetComponent<Monster>();
				monsterCount++;
			}
			startx += 1;
		}

		fireMonster.SetMonster(otherMonster);
		startx = -2.0f;

		StartCoroutine(Factory());

	}

}
