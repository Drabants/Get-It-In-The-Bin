using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngineController : MonoBehaviour

{
    [SerializeField]
    GameObject plate;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlate();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlate()
    {
        Instantiate(plate, new Vector3(0, 2, 10), Quaternion.Euler(new Vector3(-90, 0, 0)));
    }
}
