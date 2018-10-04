using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(MonstersManager))]
[RequireComponent(typeof(WeaponsManager))]
[RequireComponent(typeof(SkillsManager))]
[RequireComponent(typeof(ResourceLootManager))]

public class Managers : MonoBehaviour {

    public static PlayerManager Player { get; private set; }
    public static MonstersManager Monsters { get; private set; }
    public static WeaponsManager Weapons { get; private set; }
    public static SkillsManager Skills { get; private set; }
    public static ResourceLootManager ResourceLoot { get; private set; }

    private List<IGameManager> _startSequence;

    private void Awake()
    {
        Player = GetComponent<PlayerManager>();
        Monsters = GetComponent<MonstersManager>();
        ResourceLoot = GetComponent<ResourceLootManager>();
        Skills = GetComponent<SkillsManager>();
        Weapons = GetComponent<WeaponsManager>();

        _startSequence = new List<IGameManager>();

        _startSequence.Add(Player);
        _startSequence.Add(Monsters);
        _startSequence.Add(ResourceLoot);
        _startSequence.Add(Skills);
        _startSequence.Add(Weapons);

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        foreach (IGameManager manager in _startSequence)
        {
            manager.Startup();
        }

        yield return null;

        int numModules = _startSequence.Count;
        int numReady = 0;

        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;

            foreach (IGameManager manager in _startSequence)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }

            if (numReady > lastReady)
                Debug.Log("Progress: " + numReady + "/" + numModules);

            yield return null;
        }

        Debug.Log("All managers started up");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
