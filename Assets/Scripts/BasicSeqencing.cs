using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSeqencing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
        Debug.Log("It's good to be alive");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W was pressed");
            transform.Translate(2, 0, 0);
        }
    }
}
