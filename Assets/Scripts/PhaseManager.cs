using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PhaseManager : MonoBehaviour {
    public static PhaseManager instance;

    public bool canContinue;
    public int currentPhaseIndex;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void tryContinue() {
        if (canContinue)
            currentPhaseIndex++;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
