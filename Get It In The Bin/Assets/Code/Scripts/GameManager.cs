using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    [SerializeField]
    private GameObject plate;
    private PlateController plateController;
    private bool plateExists = false;
    GameObject plateClone;
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
        if(!plateExists)
        {
            SpawnPlate();
        }

        
    }

    void SpawnPlate()
    {
        plateExists = true;
        plateClone = Instantiate(plate, new Vector3(0, 2, 10), Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
        PlateController plateController = plateClone.GetComponent<PlateController>();
        plateController.plateIsOutOfBoundsEvent += DestroyPlate;
    }

    void DestroyPlate()
    {
        Debug.Log("Destroying the plate now");
        Destroy(plateClone);
        plateExists = false;
    }
}
