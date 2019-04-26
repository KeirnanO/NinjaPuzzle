using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    Transform player;

    public bool moveHorizontal;
    public bool moveVertical;

    public Vector3 offset;
    Vector3 position;


    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        position = offset;
        position.y = player.position.y + offset.y;
        


        if(moveHorizontal)
        {
            HorizontalControl();
        }


        transform.position = position;
    }


    void HorizontalControl()
    {

      position.x = player.position.x;

    }



}
