using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    [SerializeField]
    private GameObject tableObj;

    [SerializeField]
    private float movementSpeed = 8f;

    [SerializeField]
    float plateCenteredByZ = 1f;

    private bool goodPlate;
    private bool centered;
    private bool right;
    private bool left;
    private SwipeDetector swipeDetecor;

    public delegate void PlateIsCenteredDelegate();
    public PlateIsCenteredDelegate plateIsCenteredEvent;

    public delegate void PlateIsOutOfBoundsDelegate();
    public PlateIsOutOfBoundsDelegate plateIsOutOfBoundsEvent;

    public delegate void CorrectChoiceDelegate();
    public CorrectChoiceDelegate correctChoiceEvent;

    public delegate void IncorrectChoiceDelegate();
    public IncorrectChoiceDelegate incorrectChoiceEvent;


    void Start()
    {
        swipeDetecor = FindObjectOfType<SwipeDetector>();
        transform.position = new Vector3(transform.position.x, transform.position.y, 10f);
        SetPlateState();
    }

    private void SetPlateState()
    {
        int rando = Random.Range(0, 2);
        Debug.Log(rando);
        if (rando == 1)
        {
            goodPlate = false;
            var render = this.GetComponent<Renderer>();
            render.material.SetColor("_Color", Color.red);
        }
        else
        {
            goodPlate = true;
            var render = this.GetComponent<Renderer>();
            render.material.SetColor("_Color", Color.green);
        }
    }

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
        if (transform.position.z > plateCenteredByZ)
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
            if (!goodPlate)
            {
                correctChoiceEvent?.Invoke();
                Debug.Log("You chose correctly");
            }
            else
            {
                //Decrease lives here
                incorrectChoiceEvent?.Invoke();
                Debug.Log("YOU THREW OUT A GOOD PLATE DUMMY");
            }
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
            if (goodPlate)
            {
                correctChoiceEvent?.Invoke();
                Debug.Log("You chose correctly");
            }
            else
            {
                //Decrease lives here
                incorrectChoiceEvent?.Invoke();
                Debug.Log("YOU SERVED A BAD PLATE!!!!");
            }
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
