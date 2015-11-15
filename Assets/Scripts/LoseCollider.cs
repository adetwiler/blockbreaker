using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	private Vector3 originalBallPos;
	private Ball ball;
	
	const string LOSE_SCREEN = "Lose Screen";
	
	void Awake () {
		ball = GameObject.FindObjectOfType<Ball> ();
		originalBallPos = ball.transform.position;
	}
	
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnTriggerEnter2D (Collider2D trigger) {		
		if (LivesManager.GetLives () - 1 <= 0) {
			levelManager.LoadLevel (LOSE_SCREEN);
			LivesManager.ResetLives ();
			Ball.hasStarted = false;
		} else {
			LivesManager.RemoveLife ();
		}
		
		Ball.hasStarted = false;
		ball.transform.position = originalBallPos;
		
		LivesManager.UpdateLivesUI ();
	}
}
