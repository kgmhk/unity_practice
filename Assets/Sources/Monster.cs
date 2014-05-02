using UnityEngine;
using System.Collections;

//몬스터 가상황 에따 라변하 는모습 을컨트롤하 는스크립 트

public class Monster : MonoBehaviour {

	private Animator animator = null;
	private MonsterState state = MonsterState.MonsterState_NONE;
	private float interval = 0.0f;
	private float intervalMax = 0.2f;
	private int hp = 10;    //monster hp
	public bool isFireMonster = false; //true  일경 우fireMonster
	private Monster[] otherMonster = null;


	public enum MonsterState
	{
		MonsterState_NONE = -1,
		MonsterState_IDLE,
		MonsterState_DAMAGE,
		MonsterState_DIE,

	}

	void Start () {
		//Component 를얻어온 다. 
		// <가져 올컴포넌 트>
		animator = this.GetComponent<Animator>();
		state = MonsterState.MonsterState_IDLE;
		animator.SetInteger("State", (int)state);

		this.rigidbody2D.velocity = new Vector2(0, -2.0f);

	}

	public void SetMonster(Monster[] monster){
		otherMonster = monster;


	}


	//fireMonster 일경 우Monster 전 체삭
	public void Die(){
		state = MonsterState.MonsterState_DIE;
		animator.SetInteger("State", (int)state);
	}

	//2D 가없 을경 우3D
	void OnTriggerEnter2D(Collider2D other){
		interval = 0.0f;
		print("OnTriggerEnter2DMonster" + other.name);
		//총알 을맞았 을경 우
		if(state == MonsterState.MonsterState_IDLE){
			state = MonsterState.MonsterState_DAMAGE;
			animator.SetInteger("State", (int)state);

		}
		hp--;
		/*else if(state == MonsterState.MonsterState_DAMAGE && hp == 0)
		{
			state = MonsterState.MonsterState_DIE;
			animator.SetInteger("State", (int)state);
		}*/
		if(hp <= 0)
		{
			if(isFireMonster == true){
				foreach(Monster monster in otherMonster)
				{
					if(monster == null)
						continue;

					monster.Die();
				}
			}
			Die ();
		}

	}


	//monster destroy function
	void kill()
	{
		Destroy(this.gameObject);
	}

	
	void Update () {

		if(state == MonsterState.MonsterState_DAMAGE)
		{
			interval += Time.deltaTime;
			if(interval > intervalMax){
				interval = 0.0f;
				state = MonsterState.MonsterState_IDLE;
				animator.SetInteger("State", (int)state);
			}
		}
	

		/*
		//mouse left click
		if(Input.GetMouseButtonDown(0) == true){
			// C#에서 는포인트 가.으 로표현 됨
			animator.SetInteger("State", 0);
		}
		else if(Input.GetMouseButtonDown(1) == true){

			animator.SetInteger("State", 1);

		}*/
	}
}
