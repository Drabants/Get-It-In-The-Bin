using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public int countdownTimer;
    public Text countdownDisplay;

    private void Start()
    {
        StartCoroutine(CountDown());
    }
    IEnumerator CountDown()
    {
        while(countdownTimer > 0)
        {
            countdownDisplay.text = countdownTimer.ToString();
            yield return new WaitForSeconds(1f);
            countdownTimer--;
        }
    }
}
