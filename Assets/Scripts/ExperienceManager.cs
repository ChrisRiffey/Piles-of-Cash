using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour 
	{

	public bool waitForClick = false;
	public int chapter = 0;
	public AudioClip clip1;

	// Use this for initialization
	void Start ()
		{
		
		}
	
	// every frame
	void Update () 
		{
		if( (Input.GetButtonDown("Fire1")) && (waitForClick = true) )// if fire button pressed and waitForClick is true
			{
			chapter += 1; // increment to next chapter
			//runSection (chapter); // run next chapter
			waitForClick = false; // disable wait
			}
		}

	IEnumerator chapter1()
		{
		playAudio
		}



	// call to advance to next 
	void runSection(int section)
		{
		switch (section)
			{
		case 1:
			playAudio (1);
			spawnCash (section)
			waitForClick = true;
			break;
		case 2:

			break;
		case 2:

			break;
		case 2:

			break;
		case 2:

			break;
		case 2:

			break;
		case 2:

			break;
		case 2:

			break;
		case 2:

			break;
		case 2:

			break;
		case 2:

			break;
		case 2:

			break;
		case 2:

			break;
			}
		}
	//play specified audio file 
	void playAudio(int file)
		{
		
		}
	void spawnCash
		{
	
		}
}