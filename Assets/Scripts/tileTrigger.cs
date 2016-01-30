using UnityEngine;
using System.Collections;

public class tileTrigger : MonoBehaviour {

    public tileManager levelTileManager;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void OnTriggerEnter () {
        Debug.Log("HAS ENTERED NEW TRIGGER " + transform.parent.name);
        levelTileManager.enterTile(transform.parent.name);
	}
}
