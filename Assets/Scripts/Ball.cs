using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public static bool hasStarted = false;

	private Paddle paddle;
	private Vector3 paddleToBallVector;
	
	const int LEFT_MOUSE_BUTTON = 0;
	
	const float BALL_VELOCITY_X = 2f;
	const float BALL_VELOCITY_Y = 10f;
	const float BALL_RANGE_MIN = 0f;
	const float BALL_RANGE_MAX = 0.2f;

	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = transform.position - paddle.transform.position;
	}
	
	void Update () {
		if (!hasStarted) {
			transform.position = paddle.transform.position + paddleToBallVector;
			
			if (Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON)) {
				hasStarted = true;
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (BALL_VELOCITY_X, BALL_VELOCITY_Y);
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		Vector2 tweak = new Vector2 (Random.Range(BALL_RANGE_MIN, BALL_RANGE_MAX), Random.Range(BALL_RANGE_MIN, BALL_RANGE_MAX));
	
		if (hasStarted) {
			GetComponent<AudioSource> ().Play ();

			GetComponent<Rigidbody2D> ().velocity += tweak;
		}
	}
}
