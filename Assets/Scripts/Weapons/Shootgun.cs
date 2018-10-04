using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shootgun))]

public class Shootgun : MonoBehaviour, WeaponInterface {
    [SerializeField] private GameObject bulletPrefab;
    public float shootingFrequency = 1f;
    public float bulletLifeTime = 0.1f;
    public float damage = 2.0f;
    public float speed = 50.0f;

    public int projectilesCount = 10;
    public float spreadingAngle = 20.0f;

    private bool shootInProcess = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
        for (var i = 0; i < projectilesCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, startPos, Quaternion.identity) as GameObject;

            Vector3 newDirectionWithSpreading = direction;

            newDirectionWithSpreading = Quaternion.Euler(Random.Range(-spreadingAngle, spreadingAngle), Random.Range(-spreadingAngle, spreadingAngle), 0) * newDirectionWithSpreading;

            bullet.GetComponent<Bullet>().SendBulletToFly(newDirectionWithSpreading, bulletLifeTime, damage, speed);
        }
        yield return new WaitForSeconds(shootingFrequency);

        shootInProcess = false;
    }
}
