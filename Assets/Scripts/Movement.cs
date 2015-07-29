using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float shot_speed;

	void Start () {
		GetComponent<Rigidbody> ().velocity = transform.forward * shot_speed;
	}
}
