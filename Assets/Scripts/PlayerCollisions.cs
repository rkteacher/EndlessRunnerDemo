using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    
    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            GameManager.Instance.GameOver();
            //TODO connect this to Game Manager and trigger GameOver
        }

        if (other.gameObject.TryGetComponent(out AmmoBox ammo))
        {
            ammo.Collect();
        }
        
    }

   



}
