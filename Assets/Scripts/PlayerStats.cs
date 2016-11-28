using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	[Range(0,1)]
	public int PlayerNumber;
	public float HealthPoints;
    private float actionTime;
    public float actionDuration = 0.5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddHealth(float delta) {
		HealthPoints += delta;
	}

    public void TimeAction()
    {
        actionTime = Time.realtimeSinceStartup;
    }

    private float timeSinceLastAction()
    {
        return Time.realtimeSinceStartup - actionTime;
    }

    public bool actionDurationOver()
    {
        return (timeSinceLastAction() > actionDuration);
    }
}
