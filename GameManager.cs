using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int scene;

    public Enemy[] enemies;

    // Update is called once per frame
    void Update()
    {
        enemies = FindObjectsOfType<Enemy>();

        if(enemies.Length == 0)
        {
            //Complete Level
            SceneManager.LoadScene(scene + 1);
        }


        if(Input.GetKeyDown("joystick button 3"))
        {
            SceneManager.LoadScene(scene);
        }
    }
}
