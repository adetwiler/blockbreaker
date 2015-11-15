using UnityEngine;
using System.Collections;

public class LivesManager : MonoBehaviour {

	private static int lives = 3;
	
	const int MAX_LIVES = 3;
	const float LIFE_X_POS = 0.5f;
	const string LIFE_POS = "LifePos";
	const string LIFE_TAG = "Life";
	
	const string BALL_ASSET = "Sprites/ball";

	void Start () {
		UpdateLivesUI ();
	}

	public static void UpdateLivesUI () {
		DestroyOldLives ();
		
		SetLives();
	}
	
	private static void DestroyOldLives () {
		GameObject[] lifeObjects = GameObject.FindGameObjectsWithTag (LIFE_TAG);
		
		foreach (GameObject lifeObject in lifeObjects) {
			Destroy (lifeObject);
		}
	}
	
	private static void SetLives () {
		float newPos = 0f;
		
		for (int i = 1; i <= lives - 1; i++) {
			GameObject life = SetupLife (i);
			
			CreateLives (life, newPos);
			
			Destroy (life);
			
			newPos += LIFE_X_POS;
		}
	}
	
	private static GameObject SetupLife (int index) {
		GameObject life = new GameObject ("Life" + index);
		
		life.AddComponent<SpriteRenderer> ();
		life.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (BALL_ASSET);
		life.tag = LIFE_TAG;
		
		return life;
	}
	
	private static void CreateLives (GameObject life, float newPos) {
		GameObject lifePos = GameObject.Find (LIFE_POS);
		
		Vector3 newLifePos = new Vector3 (lifePos.transform.position.x + newPos, lifePos.transform.position.y, lifePos.transform.position.z);
		Instantiate(life, newLifePos, life.transform.rotation);
	}
	
	public static int GetLives () {
		return lives;
	}
	
	public static void AddLife () {
		lives++;
		
		UpdateLivesUI ();
	}
	
	public static void RemoveLife () {
		lives--;
		
		UpdateLivesUI ();
	}
	
	public static void ResetLives () {
		LivesManager.lives = MAX_LIVES;
	}
}
