using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] BoxCollider2D foodSpawnArea;

    void Start() 
    {
        RandomizePosition();
    }

    void RandomizePosition()
    {
        Bounds bounds = this.foodSpawnArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        //Rounding the values
        this.transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
    }
}
