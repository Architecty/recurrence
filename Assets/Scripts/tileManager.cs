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

    public GameObject[][] transitPools;

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

    //void createPools()
    //{
    //    for (int i = 0; i < )
    //}

    void initializeVariables()
    {
        playerCamera = playerController.transform.GetComponentInChildren<Camera>();
        levelSuccess = new int[choiceTiles.Length];
        for(int i = 0; i < levelSuccess.Length; i++)
        {
            levelSuccess[i] = 0;
        }
    }

    public void enterTile(string tileName)
    {

    }

    void moveToChoice(int choiceNum)
    {

    }

    void moveToTransit(int choiceNum)
    {
        //Deactivate all of the old tiles

        //Find all of the current tile's entrance/exit points

        //Find the next tile

        //Activate a number of the tiles equal to the current tile's entrance/exit points

        //Place the tiles with the entrance point touching all of the current tile's entrance/exit points
    }


    void deactivateTile(GameObject tile)
    {
        Destroy(tile);
    }

    //Create / activate a new tile of a certain type, with its entry point in the same place as the 
    void activateTile(GameObject tile, Transform exitPoint)
    {
        Instantiate(tile, exitPoint.position, exitPoint.rotation);
    }
}
