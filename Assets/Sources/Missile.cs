using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	void Start () {
		this.rigidbody2D.velocity = new Vector2(0, 5.0f);
	}
}
