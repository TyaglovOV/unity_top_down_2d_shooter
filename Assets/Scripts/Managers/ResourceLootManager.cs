using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLootManager : MonoBehaviour, IGameManager
{
    [SerializeField] private GameObject healthOrbPrefab;
    [SerializeField] private GameObject manaOrbPrefab;

    public ManagerStatus status { get; private set; }

    public int maxHealthOrbsCount = 10;
    public int maxManaOrbsCount = 10;

    public int healthOrbStrength = 10;
    public int manaOrbStrength = 30;

    public int manaDropChanceInPercent = 10;

    private int healthOrbCount = 0;
    private int manaOrbCount = 0;

    private PlayerManager player;

    public void Startup()
    {
        Debug.Log("Loot manager starting...");

        status = ManagerStatus.Started;
    }

    // Use this for initialization
    void Start()
    {
        player = Managers.Player;
    }

    public void DropSomeLoot(Vector3 coords)
    {
        if (player != null)
        {
            // check, if player health is close to critical
            if (((float)player.maxHealth - (float)player.health) / (float)player.maxHealth > Random.Range(0f, 1.0f))
            {
                if (healthOrbCount < maxHealthOrbsCount)
                {
                    Instantiate(healthOrbPrefab, coords, Quaternion.identity);
                    healthOrbCount++;
                }
            }

            // check for mana drop
            if ((float)manaDropChanceInPercent / 100.0f > Random.Range(0f, 1.0f))
            {
                if (manaOrbCount < maxManaOrbsCount)
                {
                    Instantiate(manaOrbPrefab, coords, Quaternion.identity);
                    manaOrbCount++;
                }
            }
        }
    }
    
    public void PickupHealthOrb()
    {
        healthOrbCount--;

        if (player != null)
        {
            player.ChangeHealth(healthOrbStrength);
        }
    }

    public void PickupManaOrb()
    {
        manaOrbCount--;

        if (player != null)
        {
            player.ChangeMana(manaOrbStrength);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
