using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public void LoadLevel (string name) {
		Application.LoadLevel (name);
		Brick.breakableCount = 0;
	}
	
	public void LoadNextLevel () {
		Application.LoadLevel (Application.loadedLevel + 1);
		Brick.breakableCount = 0;
	}
	
	public void QuitGame () {
		Application.Quit ();
	}
	
	public void BrickDestroyed () {
		if (Brick.breakableCount <= 0) {
			Ball.hasStarted = false;
			
			LoadNextLevel ();
			LivesManager.AddLife ();
		}
	}
}
