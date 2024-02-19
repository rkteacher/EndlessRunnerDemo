using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{

    private GameManager gameManager;

    [SerializeField] private int ammoAmmount;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }


    public void Collect()
    {
        gameManager.currentAmmo += ammoAmmount;
        if (gameManager.currentAmmo > gameManager.maxAmmo)
        {
            gameManager.currentAmmo = gameManager.maxAmmo;
        }

        Destroy(this);
    }
}
