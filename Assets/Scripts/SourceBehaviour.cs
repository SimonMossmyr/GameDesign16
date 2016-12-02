using UnityEngine;
using System.Collections;

public class SourceBehaviour : MonoBehaviour {

    public GameObject materialToSpawn;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

  public void DestroySource() {
    Instantiate(materialToSpawn, transform.position, Quaternion.identity);
  }
}
