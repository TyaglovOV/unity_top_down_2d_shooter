using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyCharacter : MonoBehaviour {

    public float speed = 5f;
    public float dangerRange = 1f;
    public int damage = 1;

    public int basicHealth = 20;
    public int colliderDamage = 1;
    private int health;

    private GameObject taggedPlayer;

    // Use this for initialization
    void Start () {
        // two ways of finding player -- tad and collider2d; how to avoid this ?
        taggedPlayer = GameObject.FindWithTag("Player");

        health = basicHealth;
    }

    public void ChangeHealth(int healthValue)
    {
        health += healthValue;
    }

    // second method to detect player collider.
    // need to set isTrigger in collider2d in instector
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            Managers.Player.ChangeHealth(-damage);
            KillThisMonster();
        }
    }

    // Update is called once per frame
    void Update () {
        //first method to detect collider

        //if ((transform.position - taggedPlayer.transform.position).magnitude < dangerRange)
        //{
        //Managers.Player.ChangeHealth(-damage);

        //Destroy(this.gameObject);
        //}

        float step = speed * Time.deltaTime;

        if (taggedPlayer != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, taggedPlayer.transform.position, step);

        }

        if (health <= 0 )
        {
            KillThisMonster();
        }
	}

    private void KillThisMonster()
    {
        Managers.Monsters.KillMonster(transform.position);
        Destroy(this.gameObject);
    }
}
