using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject shuriken;


    // Update is called once per frame
    void LateUpdate()
    {
        GetInput();
    }


    void GetInput()
    {
        if (Input.GetKeyDown("m"))
        {
            Instantiate(shuriken, transform.position, Quaternion.identity);
        }
    }

}
