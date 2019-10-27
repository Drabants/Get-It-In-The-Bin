using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    [SerializeField]
    private GameObject tableObj;

    private float movementSpeed = 8f;
    bool centered = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
        if (centered)
        {
            MoveRight();
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
            //centered = true;
        }
    }

    void MoveLeft()
    {
        if (transform.position.x > -10)
        {
            transform.position += -transform.right * Time.deltaTime * movementSpeed;
        }
    }

    void MoveRight()
    {
        if (transform.position.x < 10)
        {
            transform.position += transform.right * Time.deltaTime * movementSpeed;
        }

    }
}
