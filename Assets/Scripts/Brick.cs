using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip crack;
	public GameObject smoke;
	
	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;
	
	const float CRACK_VOLUME = 0.25f;
	const string BRICK_BREAKABLE_TAG = "Breakable";
	
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesHit = 0;
		isBreakable = (tag == BRICK_BREAKABLE_TAG);
		
		if (isBreakable) {
			breakableCount++;
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		if (isBreakable) {
			AudioSource.PlayClipAtPoint (crack, transform.position, CRACK_VOLUME);
			HandleHits ();
		}
	}
	
	void HandleHits () {
		timesHit++;
		
		int maxHits = hitSprites.Length + 1;
		
		if (timesHit >= maxHits) {		
			breakableCount--;
			
			levelManager.BrickDestroyed ();
			PuffSmoke ();
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}
	
	void PuffSmoke () {
		GameObject smokePuff = Instantiate (smoke, transform.position, transform.rotation) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer> ().color;
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		
		if (hitSprites[spriteIndex]) {
			GetComponent<SpriteRenderer> ().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError ("Brick sprite " + spriteIndex + " missing.");
		}
	}
}
