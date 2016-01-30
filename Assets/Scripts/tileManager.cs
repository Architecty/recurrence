    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class tileManager : MonoBehaviour {

    public GameObject playerController;
    private Camera playerCamera;

    //These two tiles mark the start and end of the level
    public GameObject startTile;
    public GameObject endTile;

    //These tiles are generated as you move forward. There will always be one more transit tile than there is action tile
    //(for the space between the last action tile and the end tile)
    public GameObject[] tileList;

    public GameObject currentTileGameObject;
    public List<GameObject> nextTilePool;

    public GameObject[][] transitPools;

    //This is your state of progress, and used to score at the end of the level, as well as show where your next step is.
    //0 means you haven't passed through the level. 1 is that you passed it. All other numbers are failures of some variety.
    public int[] levelSuccess = new int[0];

    //The current stage you're in. This informs the system regarding which tile to put next.
    public int currentTile = 0;

    // Use this for initialization
    void Start () {
        initializeVariables();
        createNextTiles();
    }
	
    // Update is called once per frame
    void Update () {

    }

    void initializeVariables()
    {
        playerCamera = playerController.transform.GetComponentInChildren<Camera>();
        levelSuccess = new int[tileList.Length];
        for(int i = 0; i < levelSuccess.Length; i++)
        {
            levelSuccess[i] = 0;
        }
    }

    public void enterTile(GameObject thisTile)
    {
        for(var i = 0; i < tileList.Length; i++)
        {
            Debug.Log(i);
            if (tileList[i].name == thisTile.name)
            {
                Debug.Log("Progressed To Tile " + i);
                currentTile = i;
                GameObject previousGameObject = currentTileGameObject;
                currentTileGameObject = thisTile;
                Destroy(previousGameObject);
                foreach (GameObject pastTile in nextTilePool)
                {
                    if (pastTile == thisTile)
                    {
                        nextTilePool.Remove(pastTile);
                        break;
                    }
                }
                moveToNextTile();
            }
        }
    }

    void moveToNextTile()
    {
        //Deactivate all of the old tiles
        foreach(GameObject pastTile in nextTilePool)
        {
            deactivateTile(pastTile);
        }
        nextTilePool = new List<GameObject>();
        createNextTiles();
    }

    void createNextTiles()
    {

        //Find the next tile
        GameObject nextTile = tileList[currentTile + 1];

        //Activate a number of the tiles equal to the current tile's entrance/exit points
        foreach (Transform t in currentTileGameObject.transform)
        {
            if (t.name == "Portals")
            {

                foreach (Transform x in t.transform)
                {
                    if (x.tag == "Entrance" || x.tag == "Exit")
                    {
                        Debug.Log("FOUND TAG");
                        activateTile(nextTile, x);
                    }
                }
            }
        }
    }

    void deactivateTile(GameObject tile)
    {
        if(tile.name == "Start")
        {
            tileList[0] = new GameObject();
        }
        Destroy(tile);
    }

    //Create / activate a new tile of a certain type, with its entry point in the same place as the 
    void activateTile(GameObject tile, Transform exitPoint)
    {
        GameObject newTile = Instantiate(tile, exitPoint.position, exitPoint.rotation) as GameObject;
        newTile.name = tile.name;
        nextTilePool.Add(newTile);
    }
}
