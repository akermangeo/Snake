using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using SnakeGameLib;
using SnakeGameLib.ModelObjects;
using UnityEngine;
public class SankeGameControllerScript : MonoBehaviour
{
    public GameObject _snakeGameElement;
    public SnakeGameWrapper SnakeGameWrapper;
    // Start is called before the first frame update
    void Start()
    {
        SnakeGameWrapper = SnakeGameWrapper.Create();
        Snake snake = SnakeGameWrapper.GetSnake();
        CreateHead(snake.Head());
        foreach (var point in snake.Body())
        {
            CreateBody(point);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SnakeGameWrapper.HasNewFoodPoint())
        {
            CreateFood(SnakeGameWrapper.GetFoodPoint());
        }
    }

    void CreateHead(Point point)
    {
        Instantiate(_snakeGameElement, new Vector3(point.X, point.Y, 0), transform.rotation);
    }

    private void CreateBody(Point point)
    {
        Instantiate(_snakeGameElement, new Vector3(point.X, point.Y, 0), transform.rotation);
    }

    private void CreateFood(Point point)
    {
        Instantiate(_snakeGameElement, new Vector3(point.X, point.Y, 0), transform.rotation);
    }
}