using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// at first initialization bullet was in Start() method. next I move init to another method, and init bullet manually;
public class Bullet : MonoBehaviour
{

    private float bulletSpeed;
    private float bulletLifeTime;
    private float damage;

    private Vector3 targetPoint;
    private Vector3 bulletDirection;
    private Vector3 direction;

    void Update()
    {
        if (direction != null)
        {
            transform.Translate(-direction.x * bulletSpeed * Time.deltaTime, -direction.y * bulletSpeed * Time.deltaTime, 0);
        }
    }

    public void SendBulletToFly(Vector3 direct, float lifeTime, float bulletDamage, float speed)
    {
        direction = direct;

        bulletLifeTime = lifeTime;
        damage = bulletDamage;
        bulletSpeed = speed;

        StartCoroutine(BulletLife());
    }

    // should I move this collision detector to monster itself?
    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyCharacter enemy = collision.GetComponent<EnemyCharacter>();
        if (enemy != null)
        {
            enemy.ChangeHealth((int)-damage);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator BulletLife()
    {
        yield return new WaitForSeconds(bulletLifeTime);

        Destroy(this.gameObject);
    }

    void Start()
    {

    }
}
