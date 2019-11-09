using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript: MonoBehaviour {

	//得点を呼び出す
	public int pt = 0;

	void Awake (){
		DontDestroyOnLoad (gameObject);
	}
}
