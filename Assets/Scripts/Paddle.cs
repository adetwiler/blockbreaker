using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public float minX;
	public float maxX;
	
	private Ball ball;

	const int GAME_UNITS = 16;
	
	const float PADDLE_X = 0.5f;
	const float PADDLE_Z = 0f;

	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	}

	void Update () {
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay ();
		}
	}
	
	void MoveWithMouse () {
		Vector3 paddlePos = new Vector3 (PADDLE_X, transform.position.y, PADDLE_Z);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * GAME_UNITS;
		
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
		
		transform.position = paddlePos;
	}
	
	void AutoPlay () {
		Vector3 paddlePos = new Vector3 (PADDLE_X, transform.position.y, PADDLE_Z);
		Vector3 ballPos = ball.transform.position;
		
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		
		transform.position = paddlePos;
	}
}
