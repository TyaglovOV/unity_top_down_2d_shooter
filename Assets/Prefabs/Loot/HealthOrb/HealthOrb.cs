using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LootableObject))]

public class HealthOrb : MonoBehaviour
{
    private ResourceLootManager resource;

    private void Start()
    {
        resource = Managers.ResourceLoot;
    }

    // we using this method on pickup. need to connect lootable object and this component not throught standart OnDestroy, how ?
    void OnDestroy()
    {
        if (resource != null)
        {
            resource.PickupHealthOrb();
        }
    }
}
