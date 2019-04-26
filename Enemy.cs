using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    PlayerMovement player;


    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("shuriken"))
        {
            //Multiplayer 
            //player = shuriken.GetPlayer();

            TakeDamage();
            Destroy(collision);
        }
    }

    //Overridable                         
    virtual public void TakeDamage()
    {
        player.AddJump();
        player.AddShuriken();
        Destroy(gameObject);
    }

}
