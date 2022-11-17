using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2 moveDirection = Vector2.up;

    void Update()
    {
       Movement(); 
    }

    void Movement()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveDirection = Vector2.up;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDirection = Vector2.down;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDirection = Vector2.left;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDirection = Vector2.right;
        }
    }
}
