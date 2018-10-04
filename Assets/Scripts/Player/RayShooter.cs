using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    
    private WeaponsManager weapon;

    // Use this for initialization
    void Start()
    {
        weapon = Managers.Weapons;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (weapon != null)
            {
                weapon.Shoot(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }
}
