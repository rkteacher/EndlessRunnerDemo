using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private Transform gunTransform;
    [SerializeField] private GameObject bulletPrefab;

    void Start()
    {
        // Sets the GameManager when the games starts. Now it has a reference and can talk with the Singlton Game Manager.
        gameManager = GameManager.Instance;
    }

    public void Shoot()
    {
        if (gameManager.currentAmmo > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, Quaternion.identity);
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

            bulletRB.velocity = Vector2.right * bulletSpeed;
            gameManager.currentAmmo--;
        }
    }
}
