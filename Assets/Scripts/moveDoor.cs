using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class moveDoor : MonoBehaviour
{
    public Transform pivotObject;
    public float speed = 5.0f;
    private float doorRotation = 101.0f;
    public bool isDoorDown;
    public TextMeshProUGUI TimerText;
    private float Timer;
    public int damage;
    public int points;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI pointsMadeText;
    public GameObject gameOverPanel;
    public GameObject spawner;
    
   

    // Start is called before the first frame update
    void Start()
    {
        isDoorDown = true;
        Timer = 30f;
        damage = 5;
        points = 0;
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayTime(); 
        DamageCastle();

        pointsText.text = "Farmer saved: " + points; // display points
        
        // rotate door
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            if (isDoorDown) 
            {
                transform.RotateAround(pivotObject.position, Vector3.right * speed * Time.deltaTime, doorRotation);
                isDoorDown = false;
            } 
            else 
            {
                transform.RotateAround(pivotObject.position, Vector3.left * speed * Time.deltaTime, doorRotation);
                isDoorDown = true;
            }
        }
    }

    public void DisplayTime()
    {
        // Timer / Countdown Set up
        Timer -= Time.deltaTime;  // counting seconds down
        int minutes = Mathf.FloorToInt(Timer / 60f); 
        int seconds = Mathf.FloorToInt(Timer % 60f);
        TimerText.text =  "Timer: " + string.Format("{0:00}:{1:00}", minutes, seconds); // Display Timer ; Format / Text

        if (Timer <= 0)
        {
            GameOver();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Thief"))
        {
            damage--;
            //Debug.Log("THIEF!");
            Destroy(other.gameObject);
        }
        
        if (other.CompareTag("Farmer"))
        {
            Timer ++;
            points++;
            //Debug.Log("FARMER!");
            Destroy(other.gameObject);
        }
    }
    void DamageCastle()
    {
        damageText.text = "Damage: " + damage;

        if (damage <= 0)
            GameOver();
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true); // GameOver Message
        pointsMadeText.text = "You saved " + points + " farmers"; // show points on GameOver Panel
        Destroy(spawner); // stop spwaning people

    }
}
