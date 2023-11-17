using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using SnakeGameLib;
using SnakeGameLib.ModelObjects;
using UnityEngine;
public class SankeGameControllerScript : MonoBehaviour
{
    public GameObject _snakeGameElement;
    private SnakeGameWrapper _snakeGameWrapper;
    // Start is called before the first frame update
    void Start()
    {
        _snakeGameWrapper = SnakeGameWrapper.Create();
        Snake snake = _snakeGameWrapper.GetSnake();
        CreateHead(snake.Head());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateHead(Point point)
    {
        Instantiate(_snakeGameElement, new Vector3(point.X, point.Y, 0), transform.rotation);
    }
}