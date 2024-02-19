using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Cactito : MonoBehaviour
{
    public float speed;
    [SerializeField] Rigidbody2D enemyRB;

    [SerializeField] private float timeUntilDuck;
    [SerializeField] private float maxDuckTime;
    [SerializeField] private float minDuckTime;
    [SerializeField] private CapsuleCollider2D cactitoCollider;
    [SerializeField] private float vunerableTime = 2f;
    [SerializeField] private Animator cactitoAnimator;

    private float duckTime;
    private bool isShooting;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform gunTransform;
    [SerializeField] private float bulletSpeed;



    // Start is called before the first frame update
    void Start()
    {
        cactitoCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        
        DuckTimer();

        
    }


    private void DuckTimer()
    {
        duckTime += Time.deltaTime;

        if (duckTime >= timeUntilDuck)
        {
            StartCoroutine(Shoot());
            
        }
    }

    private IEnumerator Shoot()
    {
        //TODO change the animation
        cactitoCollider.size = new Vector2(1f, 2f);
        cactitoCollider.offset = new Vector3(0, 0f);

        if(isShooting == false)
        {
            GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, Quaternion.identity);
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

            bulletRB.velocity = Vector2.left * bulletSpeed;
            isShooting = true;
            cactitoAnimator.SetBool("isShooting", true);
        }
        
        yield return new WaitForSeconds(3);

        cactitoCollider.size = new Vector2(1f, 1f);
        cactitoCollider.offset = new Vector3(0, -0.5f);
        timeUntilDuck = Random.Range(minDuckTime, maxDuckTime);
        duckTime = 0f;
        isShooting = false;
        cactitoAnimator.SetBool("isShooting", false);

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Bullet")
        {
            gameObject.SetActive(false);
            Destroy(other.gameObject);
            GameManager.Instance.EnemyDefeated();
        }
    }
}
