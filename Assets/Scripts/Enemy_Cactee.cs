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

}
