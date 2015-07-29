using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;

	Vector3 offset;

	void Start() {
		offset = transform.position - target.position;
	}

	void FixedUpdate() {
		Vector3 target_camera_pos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, target_camera_pos, smoothing * Time.deltaTime);

	}
}
