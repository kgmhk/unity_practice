using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour 
{
	int a = 10;
	float b = 0.1f;
	string name = "kim";
	bool c = true;

	void sum(int c)
	{

		int result = a + 50 + c;
		print ("result : " + result);
	}

	// Use this for initialization
	void Start () 
	{
		//print("Start!!!!!");
		Debug.Log ("Start!!!!");
		Debug.Log (a);
		Debug.Log (b);
		Debug.Log (name);
		Debug.Log (c);
		sum (40);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
