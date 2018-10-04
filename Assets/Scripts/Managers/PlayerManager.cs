using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{

    public ManagerStatus status { get; private set; }

    public int health { get; private set; }
    public int maxHealth { get; private set; }
    public int defaultStartupHealth = 50;
    public int defaultMaxHealth = 150;

    public int mana { get; private set; }
    public int maxMana { get; private set; }
    public int defaultStartupMana = 100;
    public int defaultMaxMana = 100;


    // our var for delaying damage for player, when receiving hit
    public float shimmeringTime = 0.5f;
    private bool _isShimmering;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            GameObject taggedPlayer;
            taggedPlayer = GameObject.FindWithTag("Player");

            if (taggedPlayer != null)
            {
                taggedPlayer.SetActive(false);
            }
        }
    }

    public void Startup()
    {
        Debug.Log("Player manager starting...");

        health = defaultStartupHealth;
        maxHealth = defaultMaxHealth;

        mana = defaultStartupMana;
        maxMana = defaultMaxMana;

        _isShimmering = false;

        status = ManagerStatus.Started;
    }

    public void ChangeHealth(int healthValue)
    {

        //start shimmering (temp invulnerability)
        if (healthValue < 0)
        {
            if (!_isShimmering)
            {
                health = ResourceTrimmer(health, maxHealth, healthValue);
                _isShimmering = true;
                StartCoroutine(Shimmering());
            }
        }

        else
        {
            health = ResourceTrimmer(health, maxHealth, healthValue);
        }
    }

    public void ChangeMana(int manaValue)
    {
        mana = ResourceTrimmer(mana, maxMana, manaValue);
    }

    private int ResourceTrimmer(int mainResource, int maxResource, int resourceValue)
    {
        mainResource += resourceValue;

        if (mainResource > maxResource)
        {
            mainResource = maxResource;
        }

        else if (mainResource < 0)
        {
            mainResource = 0;
        }

        return mainResource;
    }

    private IEnumerator Shimmering()
    {
        yield return new WaitForSeconds(shimmeringTime);

        _isShimmering = false;
    }
}
