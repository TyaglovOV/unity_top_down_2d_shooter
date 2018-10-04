using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LootableObject))]

public class ManaOrb : MonoBehaviour {
    private ResourceLootManager resource;

    private void Start()
    {
        resource = Managers.ResourceLoot;
    }

    void OnDestroy()
    {
        if (resource != null)
        {
            resource.PickupManaOrb();
        }
    }
}
