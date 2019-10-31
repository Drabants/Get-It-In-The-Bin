using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    [SerializeField]
    private GameObject plate;

    private bool plateCentered = false;
    private int score = 0;
    private int lives = 3;
    private float timeLeft = 120.0f;
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
