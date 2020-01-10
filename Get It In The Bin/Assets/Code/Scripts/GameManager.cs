using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    [SerializeField]
    private GameObject plate;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Image heart0;
    [SerializeField]
    private Image heart1;
    [SerializeField]
    private Image heart2;
    public Sprite fullHeart;
    public Sprite emptyHeart;
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
        scoreText.text = score.ToString();
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
        plateController.correctChoiceEvent += IncreaseScore;
        plateController.incorrectChoiceEvent += DecreaseLives;
        plateController.plateIsOutOfBoundsEvent += DestroyPlate;
    }

    void IncreaseScore()
    {
        score += 100;
        scoreText.text = score.ToString();
    }

    void DecreaseLives()
    {
        lives--;
        DisplayLives();
    }

    private void DisplayLives()
    {
        switch (lives)
        {
            case 0:
                heart0.sprite = emptyHeart;
                break;
            case 1:
                heart1.sprite = emptyHeart;
                break;
            case 2:
                heart2.sprite = emptyHeart;
                break;
        }
    }

    void DestroyPlate()
    {
        Debug.Log("Destroying the plate now");
        Destroy(plateClone);
        plateExists = false;
    }
}
