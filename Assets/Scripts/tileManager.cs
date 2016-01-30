    using UnityEngine;
    using System.Collections;

    public class tileManager : MonoBehaviour {

    public GameObject playerController;
    private Camera playerCamera;

    //These two tiles mark the start and end of the level
    public GameObject startTile;
    public GameObject endTile;

    //These tiles are generated as you move forward. There will always be one more transit tile than there is action tile
    //(for the space between the last action tile and the end tile)
    public GameObject[] transitTiles;
    public GameObject[] choiceTiles;

    //This is your state of progress, and used to score at the end of the level, as well as show where your next step is.
    //0 means you haven't passed through the level. 1 is that you passed it. All other numbers are failures of some variety.
    public int[] levelSuccess = new int[0];

    //The current stage you're in. This informs the system regarding which tile to put next.
    public int currentStage = 0;

    // Use this for initialization
    void Start () {
        initializeVariables();

    }
	
    // Update is called once per frame
    void Update () {
	
    }


    void initializeVariables()
    {
        playerCamera = playerController.transform.GetComponentInChildren<Camera>();
        levelSuccess = new int[actionTiles.Length];
        for(int i = 0; i < levelSuccess.Length; i++)
        {
            levelSuccess[i] = 0;
        }
    }
  }
