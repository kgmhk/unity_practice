using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed = 300;

	void FixedUpdate()
	{
		// 왼 쪽방향 을눌렀 나오른쪽방향 을눌렀나 를알려준다
		float dirX = Input.GetAxis("Horizontal");
		float dirY = Input.GetAxis("Vertical");
		//print ("dir" + dir);

		//움직 임처  리
		//300 : speed 
		//dir : 방 향
		float x = dirX * speed * Time.deltaTime;
		float y = dirY * speed * Time.deltaTime;
		//velocity : 속 도-> 방 향 * 속 력
		//어 느방향 의어 느값 을넣 어달 라
		//new 라 고붙이 면메모 리공간 에올린 다. 주소값 이존 재
		this.rigidbody2D.velocity = new Vector2(x,y);

	}
}
