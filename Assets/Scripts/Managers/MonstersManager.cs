using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersManager : MonoBehaviour, IGameManager
{
    [SerializeField] private GameObject enemyPrefab;

    public ManagerStatus status { get; private set; }

    public int defaultStartupMonstersCount = 10;
    public int countIncreasing = 1;
    public int countIncreasingTimer = 5;
    
    public float spawningDistance = 5f;
    
    private int monstersCount;
    private int aliveMonstersCount = 0;
   
    private GameObject taggedPlayer;

    private static ResourceLootManager loot;

    public void Startup()
    {
        Debug.Log("Monsters manager starting...");

        status = ManagerStatus.Started;
    }

    // Use this for initialization
    void Start ()
    {
        monstersCount = defaultStartupMonstersCount;

        loot = Managers.ResourceLoot;

        //don't like this connection with tag. how can i avoid this?
        taggedPlayer = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		if (aliveMonstersCount < monstersCount)
        {
            Instantiate(enemyPrefab, taggedPlayer.transform.position + RandomSpawningCoords(), Quaternion.identity);
            aliveMonstersCount++;
        }
    }

    public void KillMonster(Vector3 coords)
    {
        aliveMonstersCount--;

        if (loot != null)
        {
            loot.DropSomeLoot(coords);
        }
    }

    // spawn monsters around player at spawningDistance;
    private Vector3 RandomSpawningCoords()
    {
        Vector3 randomVector = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;

        randomVector.x *= spawningDistance;
        randomVector.y *= spawningDistance;
        randomVector.z = 0;

        return randomVector;
    }
}
