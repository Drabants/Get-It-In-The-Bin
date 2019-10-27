using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    [SerializeField]
    private GameObject tableObj;

    private float movementSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 10f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MoveDown()
    {
        if (transform.position.z > tableObj.transform.position.z)
        {
            transform.Translate(Vector3.back * Time.deltaTime * movementSpeed);
        }
    }

    void MoveLeft()
    {

    }

    void MoveRight()
    {

    }
}
