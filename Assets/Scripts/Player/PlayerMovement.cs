using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
	
	Vector3 movement;
	Animator anim;                     
	Rigidbody player_rb;          
	int floor_mask;                      
	float camera_ray_length = 100f;          
	
	void Awake () {
		floor_mask = LayerMask.GetMask ("Floor");
		anim = GetComponent <Animator> ();
		player_rb = GetComponent <Rigidbody> ();
	}
	
	
	void FixedUpdate () {
		// Store the input axes.
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
		Turning ();
		Animating (h, v);
	}
	
	void Move (float h, float v) {
		movement.Set (h, 0f, v);
		
		movement = movement.normalized * speed * Time.deltaTime;
		
		player_rb.MovePosition (transform.position + movement);
	}
	
	void Turning () {
		Ray camera_ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		RaycastHit floorHit;
		
		if(Physics.Raycast (camera_ray, out floorHit, camera_ray_length, floor_mask))
		{
			Vector3 player_to_mouse = floorHit.point - transform.position;
			player_to_mouse.y = 0f;	
			Quaternion new_rotation = Quaternion.LookRotation (player_to_mouse);	
			player_rb.MoveRotation (new_rotation);
		}
	}
	
	void Animating (float h, float v) {
		bool walking = h != 0f || v != 0f;		
		anim.SetBool ("IsWalking", walking);
	}
}
