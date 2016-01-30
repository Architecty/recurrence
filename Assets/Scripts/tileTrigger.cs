using UnityEngine;
using System.Collections;

public class tileTrigger : MonoBehaviour {

    public tileManager levelTileManager;

	// Use this for initialization
	void Start () {
	    levelTileManager = GameObject.find<levelTileManager>()
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
