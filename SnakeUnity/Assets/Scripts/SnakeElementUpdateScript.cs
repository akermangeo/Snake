using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SnakeElementUpdateScript : MonoBehaviour
{
    private SnakeGameWrapper _snakeGame;
    // Start is called before the first frame update
    void Start()
    {
        _snakeGame = GameObject.FindGameObjectWithTag("Manager").GetComponent<SankeGameControllerScript>().SnakeGameWrapper;
    }

    // Update is called once per frame
    void Update()
    {
        if (_snakeGame.IsEmpty(new Point((int)transform.position.x, (int)transform.position.y)))
        {
            Destroy(gameObject);
        }
    }
}
