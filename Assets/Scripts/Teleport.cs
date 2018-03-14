using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour 
	{

	// initialize variables
	private Vector3 warpTarget;
	private GameObject warpMarker;
	private Transform startMarker;
	private Transform endMarker;
	private float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	private bool warping = false;
	private float distCovered;
		
	// do every frame
	void Update () 
		{
		if(Input.GetButtonDown("Fire1")) // if fire button pressed
			{
			Ray ray; //initialize ray
			RaycastHit hit; //initialize hit 
			ray = Camera.main.ScreenPointToRay(Input.mousePosition); // raycast from screen point
			if (Physics.Raycast(ray, out hit, 100.0f)) // if raycast is hitting something
				{
				if ((hit.collider.tag == "floor") && (warping == false)) // raycast is hitting a floor object
					{
					startTime = Time.time; //record the time
					warpTarget = hit.point + new Vector3 (0, 2f, 0); // specify the warp target with offset for height
					warping = true; Debug.Log("Warping is true"); // set warping
					startMarker = gameObject.transform; // record start point
					journeyLength = Vector3.Distance (startMarker.position, warpTarget); // determine length of warp
					} 
				}
			}
		if (warping == true)  // if warping
			{	
			distCovered += Time.deltaTime * speed; // record distance covered
			float fracJourney = distCovered / journeyLength; // set current progress
			//Debug.Log("distCovered:"+distCovered+" - journeyLength:"+journeyLength+" - fracJourney:"+fracJourney+" - time:"+Time.time+" - startTime:"+startTime);
			transform.position = Vector3.Lerp (startMarker.position, warpTarget, fracJourney); // move to current progress
			if (Vector3.Distance(transform.position, warpTarget) <= 0.1f) // if distance to target is close enough
				{ 
				warping = false; Debug.Log("Warping is false"); // set not warping
				distCovered = 0.0f; // reset distance covered
				warpTarget = Vector3.zero; // reset warp target
				}
			}	
		}
	}
