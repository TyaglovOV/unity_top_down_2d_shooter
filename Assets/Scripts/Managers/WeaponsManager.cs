using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Minigun))]
[RequireComponent(typeof(Shootgun))]

public class WeaponsManager : MonoBehaviour, IGameManager
{
    [SerializeField] private GameObject bulletPrefab;
    public ManagerStatus status { get; private set; }
    private Minigun minigun;
    private Shootgun shootgun;

    public WeaponsNames selectedWeapon { get; private set; }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Startup()
    {
        Debug.Log("Weapons manager starting...");

        minigun = GetComponent<Minigun>();
        shootgun = GetComponent<Shootgun>();
        selectedWeapon = WeaponsNames.Minigun;

        status = ManagerStatus.Started;
    }

    public void Shoot(Vector3 startPos, Vector3 endPos)
    {
        switch (selectedWeapon)
        {
            case WeaponsNames.Minigun:
                minigun.Shooting(startPos, endPos);
                break;

            case WeaponsNames.Shootgun:
                shootgun.Shooting(startPos, endPos);
                break;
        }
    }

    public void SelectShootgun()
    {
        selectedWeapon = WeaponsNames.Shootgun;
    }

    public void SelectMinigun()
    {
        selectedWeapon = WeaponsNames.Minigun;
    }

    // Use this for initialization
    void Start () {
		
	}
}
