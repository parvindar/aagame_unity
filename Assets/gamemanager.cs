using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class gamemanager : MonoBehaviour {

	public bool isgameover=false;
	private int score=0;
	private int Highscore;
	public Text scoretext;
	public Text highscoretext;

	void Start()
	{
		Highscore = PlayerPrefs.GetInt ("Highscore", 0);
		highscoretext.text ="Highscore "+ Highscore.ToString ();
	}
	public void gameover()
	{
		if (isgameover)
			return;

		isgameover = true;
		FindObjectOfType<admanager> ().showinterstitial ();
		restartlevel ();
		Debug.Log ("gameover");
	}


	public void restartlevel()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}


	public void scoreupdate()
	{
		score++;
		scoretext.text = score.ToString ();
		if (score > Highscore) 
		{
			PlayerPrefs.SetInt ("Highscore", score);
			Highscore = PlayerPrefs.GetInt ("Highscore");
			highscoretext.text ="Highscore"+ Highscore.ToString ();
		}
	}
}
