using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackHome : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.instance.BackHome();
        }
    }
}
