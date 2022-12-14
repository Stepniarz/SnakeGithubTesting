using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2 moveDirection = Vector2.up;
    List<Transform> snakePartsList;
    [SerializeField] Transform snakePartPrefab;

    void Start() 
    {
        snakePartsList = new List<Transform>();
        snakePartsList.Add(this.transform);
    }

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

    void FixedUpdate() 
    {
        SnakePartsFollow();
        HeadMovement();
        
    }
    void HeadMovement()
    {
        this.transform.position = new Vector2(
            Mathf.Round(this.transform.position.x) + moveDirection.x,
            Mathf.Round(this.transform.position.y) + moveDirection.y
        );
    }

    void Grow()
    {
        Transform snakePart = Instantiate(this.snakePartPrefab);
        snakePart.position = snakePartsList[snakePartsList.Count - 1].position;     //last position from the list
        snakePartsList.Add(snakePart);
    }

    void GameReset()
    {
        for (int i = 1; i < snakePartsList.Count; i++)
        {
            Destroy(snakePartsList[i].gameObject);
        }

        snakePartsList.Clear();
        snakePartsList.Add(this.transform);
        this.transform.position = Vector2.zero;
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Food")
        {
            Grow();
        }
        else if(other.tag == "SnakePart")
        {
            GameReset();
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Border")
        {
            GameReset();
        }
    }

    void SnakePartsFollow()
    {
        for(int i = snakePartsList.Count - 1; i > 0; i--)
        {
            snakePartsList[i].position = snakePartsList[i - 1].position;
        }
    }
}
