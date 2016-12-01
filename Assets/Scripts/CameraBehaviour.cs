using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	public GameObject[] players;
	private Camera c;
    private float defaultSize = 5f;
    public float minSize = 2f;

	// Use this for initialization
	void Start () {
		c = GetComponent<Camera> ();
        defaultSize = c.orthographicSize;
	}

    // Update is called once per frame
    void Update()
    {
        // Current local player position
        Vector2 minPos = new Vector2(9999, 9999);
        Vector2 maxPos = new Vector2(-9999, -9999);
		Vector3 avgPlayerPos = new Vector3();

		// New players could have joined
		players = GameObject.FindGameObjectsWithTag ("Player");

        foreach (GameObject player in players)
        {
            Vector3 playerPos = player.transform.position;
            avgPlayerPos += playerPos;

            if (playerPos.x > maxPos.x)
            {
                maxPos.x = playerPos.x;
            }
            if (playerPos.y > maxPos.y)
            {
                maxPos.y = playerPos.y;
            }
            if (playerPos.x < minPos.x)
            {
                minPos.x = playerPos.x;
            }
            if (playerPos.y < minPos.y)
            {
                minPos.y = playerPos.y;
            }
        }

		if (players.Length == 0)
			return;

        avgPlayerPos = avgPlayerPos / players.Length;

        // Zoom camera through orthographic size for 2D
        float newOrthographicSize = Mathf.Sqrt((maxPos - minPos).sqrMagnitude) / 1.8f;
        if (newOrthographicSize > defaultSize)
        {
            newOrthographicSize = defaultSize;
        }
        else if (newOrthographicSize < minSize)
        {
            newOrthographicSize = minSize;
        }
        c.orthographicSize = newOrthographicSize;

        // Limit camera to within playfield 
        float xlimit = c.aspect;
        float ylimit = 1f;
        float cameraScale = (defaultSize - c.orthographicSize);
        if (avgPlayerPos.x > cameraScale * xlimit)
        {
            avgPlayerPos.x = cameraScale * xlimit;
        }
        else if (avgPlayerPos.x < -cameraScale * xlimit)
        {
            avgPlayerPos.x = -cameraScale * xlimit;
        }
        if (avgPlayerPos.y > cameraScale * ylimit)
        {
            avgPlayerPos.y = cameraScale * ylimit;
        }
        else if (avgPlayerPos.y < -cameraScale * ylimit)
        {
            avgPlayerPos.y = -cameraScale * ylimit;
        }

        // Move camera to average player pos
        transform.position = new Vector3(avgPlayerPos.x, avgPlayerPos.y, -10);
    }
}
