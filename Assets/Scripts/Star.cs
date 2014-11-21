using UnityEngine;
using System.Collections;

[System.Serializable]
public class Star{

	public string starName;
	public float distance;
	public Vector3 position;
	public float absoluteMagnitude;
	
	private float _relativeMagnitude = -1.0f;
	
	public float relativeMagnitude{
		get {
			if(_relativeMagnitude == -1.0f){
				_relativeMagnitude = 5 * (Mathf.Log10(distance) - 1) + absoluteMagnitude;
			}
		
			return _relativeMagnitude;	
		}
	}
}
