using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour 
	{

	public bool waitForClick = false;
	public int chapter = 0;
	public AudioSource audio;
	public AudioClip clip1;
	private AudioClip currentClip;

	// Use this for initialization
	void Start ()
		{
		waitForClick = true;
		}
	
	// every frame
	void Update () 
		{
		if( (Input.GetButtonDown("Fire1")) && (waitForClick = true) )// if fire button pressed and waitForClick is true
			{
			Debug.Log ("clicked");
			chapter += 1; // increment to next chapter
			//runSection (chapter); // run next chapter
			//waitForClick = false; // disable wait
			//playAudio();
			//currentClip = "clip"+chapter.ToString();
			Debug.Log ("currentClip is ");
			StartCoroutine("playAudio");
			}
		}


	// call to advance to next 
	void runSection(int section)
		{
		switch (section)
			{
		case 1:
			//playAudio (1)
			//spawnCash (section)
			//waitForClick = true
			break;
		case 2:

			break;
		case 3:

			break;
		case 4:

			break;
		case 5:

			break;
		case 6:

			break;
		case 7:

			break;
		case 8:

			break;
		case 9:

			break;
		case 10:

			break;
		case 11:

			break;
		case 12:

			break;
		case 13:

			break;
			}
		}
	//play specified audio file 
	IEnumerator playAudio()
		{
		Debug.Log ("Audio playing");

		audio.clip = currentClip;
		audio.Play(); 
		yield return new WaitForSeconds(audio.clip.length);
		}
	void spawnCash()
		{
	
		}
	}