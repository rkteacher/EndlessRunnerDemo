using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Cactee : MonoBehaviour
{
    public float speed;
    [SerializeField] Rigidbody2D enemyRB;



    // Start is called before the first frame update
    void Start()
    {
        enemyRB.velocity = Vector2.left * speed;
    }

    private void Update()
    {
        enemyRB.velocity = Vector2.left * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Bullet")
        {
            gameObject.SetActive(false);
            Destroy(other.gameObject);
            GameManager.Instance.EnemyDefeated();
            Debug.Log("catee got shot");

        }
    }
}
