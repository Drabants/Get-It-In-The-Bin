using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    [SerializeField]
    private GameObject tableObj;

    [SerializeField]
    private float movementSpeed = 8f;
    bool centered;
    bool right;
    bool left;

    public delegate void PlateIsCenteredDelegate();
    public PlateIsCenteredDelegate plateIsCenteredEvent;

    public delegate void PlateIsOutOfBoundsDelegate();
    public PlateIsOutOfBoundsDelegate plateIsOutOfBoundsEvent;

    private SwipeDetector swipeDetecor;
    // Start is called before the first frame update
    void Start()
    {
        swipeDetecor = FindObjectOfType<SwipeDetector>();
        transform.position = new Vector3(transform.position.x, transform.position.y, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!centered)
        { 
         MoveDown();
        }
        else
        {
            if (left)
            {
                MoveLeft();
            }
            if (right)
            {
                MoveRight();
            }

        }
    }

    void MoveDown()
    {
        if (transform.position.z > tableObj.transform.position.z)
        {
            transform.position += transform.up * Time.deltaTime *movementSpeed;
        }
        else
        {
            swipeDetecor.SwipeLeftEvent += SwipedLeft;
            swipeDetecor.SwipeRightEvent += SwipedRight;
            centered = true;
        }
    }

    void MoveLeft()
    {
        if (transform.position.x > -10)
        {
            transform.position += -transform.right * Time.deltaTime * movementSpeed;
        }
        else
        {
            plateIsOutOfBoundsEvent?.Invoke();
        }
    }

    void MoveRight()
    {
        if (transform.position.x < 10)
        {
            transform.position += transform.right * Time.deltaTime * movementSpeed;
        }
        else
        {
            plateIsOutOfBoundsEvent?.Invoke();
        }

    }

    void SwipedRight()
    {
        if (!right && !left)
        {
            right = true;
        }
    }

    void SwipedLeft()
    {
        if (!right && !left)
        {
            left = true;
        }
    }
}
