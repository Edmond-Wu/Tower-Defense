using UnityEngine;
using System.Collections;

public class BoundaryRemoval : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		Destroy (other.gameObject);
	}
}
