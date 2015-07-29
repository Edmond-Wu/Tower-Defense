using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float x_min, x_max, z_min, z_max;
}

public class Controller : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shot_gen;
	public float fire_rate;

	private float next_fire;

	void Update() {
		if ((Input.GetButton("Fire1") || Input.GetKeyDown ("space")) && Time.time > next_fire) {
			next_fire = Time.time + fire_rate;
			Instantiate(shot, shot_gen.position, shot_gen.rotation);
			GetComponent<AudioSource>().Play(); //laser shot sound effect
		}
	}

	void FixedUpdate() {
		float move_horizontal = Input.GetAxis ("Horizontal");
		float move_vertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (move_horizontal, 0.0f, move_vertical);
		GetComponent<Rigidbody>().velocity = speed * movement;

		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.x_min, boundary.x_max), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundary.z_min, boundary.z_max)
		);

		GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}


}
