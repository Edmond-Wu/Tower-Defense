using UnityEngine;
using System.Collections;

public class Destruction : MonoBehaviour {

	public GameObject explosion;
	public GameObject player_destruction;
	public int points_value;
	private GameController game_controller;

	void Start() {
		GameObject controller_obj = GameObject.FindWithTag ("GameController");
		if (controller_obj != null) {
			game_controller = controller_obj.GetComponent<GameController> ();
		} 
		else {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Borders") {
			return;
		}
		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (player_destruction, other.transform.position, other.transform.rotation);
			game_controller.GameOver ();
		}
		game_controller.AddPoints (points_value);
		Destroy(other.gameObject);
		Destroy (gameObject);
	}
}
