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
    public int points;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI pointsMadeText;
    public TextMeshProUGUI pointsMadeText2;
    public GameObject gameOverPanel;
    public GameObject gameWonPanel;
    public GameObject spawner;


    //Health Bar
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;


    private AudioSource doorAudioSource; //create audiosource-variable
   
    public Animator doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        isDoorDown = true;
        doorAnimator.SetBool("IsOpen", true);
        Timer = 30f;
        points = 0;
        gameOverPanel.SetActive(false);
        gameWonPanel.SetActive(false);

        //Health Bar
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        doorAudioSource = GetComponent<AudioSource>();    //assign audio-source of this object to the variable, the clip in the source (atmo) is set to play on awake and loop  

       // doorAnimator = GetComponent<Animator>();
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
                //transform.RotateAround(pivotObject.position, Vector3.right * speed * Time.deltaTime, doorRotation);
                doorAnimator.SetTrigger("move");
                isDoorDown = false;
                doorAnimator.SetBool("IsOpen", false);
                
            } 
            else 
            {
                doorAnimator.SetTrigger("move");
               // transform.RotateAround(pivotObject.position, Vector3.left * speed * Time.deltaTime, doorRotation);
                isDoorDown = true;
                doorAnimator.SetBool("IsOpen", true);
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
            GameWon();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Thief"))
        {
            TakeDamage(25);
            Destroy(other.gameObject);
        }
        
        if (other.CompareTag("Farmer"))
        {
            //Timer needs to go up by more than 1 second
            Timer ++;
            points++;
            Destroy(other.gameObject);
        }
    }
    void DamageCastle()
    {
        if (currentHealth <= 0)
        {
            GameOver();
        }
            
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }


    private void GameOver()
    {
        gameOverPanel.SetActive(true); // GameOver Message
        pointsMadeText.text = "You saved " + points + " farmers"; // show points on GameOver Panel
        Destroy(spawner); // stop spwaning people
        StopAtmo();


    }

    private void GameWon()
    {
        gameWonPanel.SetActive(true); // GameOver Message
        pointsMadeText2.text = "You saved " + points + " farmers"; // show points on GameOver Panel
        Destroy(spawner); // stop spwaning people
        StopAtmo();
    }

    private void StopAtmo()
    {
        if (doorAudioSource.isPlaying)
        {
            doorAudioSource.Stop();     //if game ends, stop playing atmo, the game-ending sounds are attached to the canvasses and set to play on awake
        }
    }
}
