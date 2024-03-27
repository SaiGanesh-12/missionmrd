using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float timeRemaining = 180f;
   
    void Update()
    {
        
        if ( timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; 
            UpdateTimerText();
        }
        else
        {
            ReloadScene(); 
        }
    }

    void UpdateTimerText()
    {
        int seconds = Mathf.FloorToInt(timeRemaining);
        timerText.text = "Timer: "+seconds.ToString();
    }


    void ReloadScene()
    {
        SceneManager.LoadScene("HomeScreen"); 
    }

}
