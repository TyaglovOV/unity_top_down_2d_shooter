using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : MonoBehaviour, WeaponInterface
{
    [SerializeField] private GameObject bulletPrefab;
    public float shootingFrequency = 0.2f;
    public float bulletLifeTime = 1.0f;
    public float damage = 5.0f;
    public float speed = 50.0f;

    private bool shootInProcess = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shooting(Vector3 startPos, Vector3 endPos)
    {
        if (!shootInProcess)
        {
            shootInProcess = true;
            Vector3 direction = (startPos - endPos).normalized;

            StartCoroutine(ShootingProcess(startPos, direction));
        }
    }

    private IEnumerator ShootingProcess(Vector3 startPos, Vector3 direction)
    {

        GameObject bullet = Instantiate(bulletPrefab, startPos, Quaternion.identity) as GameObject;
        
        bullet.GetComponent<Bullet>().SendBulletToFly(direction, bulletLifeTime, damage, speed);

        yield return new WaitForSeconds(shootingFrequency);

        shootInProcess = false;
    }
}
