using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text CountDown;
    public Text Score;
    public static int _score=0;
    private float timer = 0f;

    private bool newColor = true;
    public GameObject SpawnCube;
    public AudioSource AddPoint;
    public AudioSource ChangeColor;
    GameObject image;
    public GameObject DeadCam;
    public Text HighsCore;
    public Text NowScore;
    private int highScore;

  
    //Hero sphereS;
    private Color colorX;
    private Color colorY;



    //цвет начИгры
    Color color7 = new Color(1, 255f / 255f, 1);
    Color color8 = new Color(1, 220f / 255f, 1);


    private void Start()
    {
        Time.timeScale = 1;
        Hero.standart = true;
        highScore = PlayerPrefs.GetInt("highScore", 0);
        image = GameObject.FindGameObjectWithTag("BackGround");
      
        colorX = color7;
        colorY = color8;
    }

    private void Update()
    {
        if (_score > highScore)
        {
            highScore = _score;
            PlayerPrefs.SetInt("highScore", highScore);
        }


        color7 = Color.Lerp(colorX, colorY, Mathf.PingPong(Time.time, 1f));
        image.GetComponent<Image>().color=color7;
      

        timer += Time.deltaTime;
        // Debug.Log(timer);

        if (timer >= 4 && timer < 5) { CountDown.text = "Your color..."; }
        if (timer >= 5 && newColor == true)
        {
            newColor = false;

            if (ChangeColor.isPlaying == false)
            { ChangeColor.Play(); }
            GreenBack();

        }
        if (_score == 15)
        {
            if (ChangeColor.isPlaying == false)
                ChangeColor.Play(); 
            BlackBack();

        }
        if (_score == 25)
        {
            if (ChangeColor.isPlaying == false)
            { ChangeColor.Play(); }
            RedBack();
            Time.timeScale = 1.1f;
        }
        if (_score == 40)
        {
            if (ChangeColor.isPlaying == false)
            { ChangeColor.Play(); }
            BlackBack();
            Time.timeScale = 1.2f;
            

        }
        if (_score == 55)
        {
            if (ChangeColor.isPlaying == false)
            { ChangeColor.Play(); }
            RedBack();
            Time.timeScale = 1.3f;
        }
        if (_score == 65)
        {
            if (ChangeColor.isPlaying == false)
            { ChangeColor.Play(); }
            GreenBack();
            Time.timeScale = 1.4f;
        }
        if (_score == 80)
        {
            if (ChangeColor.isPlaying == false)
            { ChangeColor.Play(); }
            BlackBack();
            Time.timeScale = 1.5f;
        }
        if (_score == 80)
        {
            if (ChangeColor.isPlaying == false)
            { ChangeColor.Play(); }
            RedBack();
            Time.timeScale = 1.75f;
        }
    }
    public void AddScore()
    {
        Score.text = "" + _score;
        AddPoint.Play();
        _score += 1;

    }
    public void DeadMoment() 
    { DeadCam.SetActive(true);
        CountDown.text = "";
        HighsCore.text = "Highscore: " + highScore;
        NowScore.text = "Score: " +Score.text;
        GameObject Hero = GameObject.FindGameObjectWithTag("Player");
        Destroy(Hero);
        _score = 0;
    }
       /* IEnumerator Countdown(int seconds)
        {
            int count = seconds;

            while (count > 0)
            {

                CountDown.text = count.ToString();
                yield return new WaitForSeconds(1);
                count--;
            }
            if (count == 0)
            {
                CountDown.text = "Your color...";
            }

        }*/


    //Зеленый бэк
    void GreenBack()
    {   //greeen
     
        Hero.green = true;
        CountDown.text = "Green!";
        Color color1 = new Color(96f / 255f, 224f / 255f, 127f / 255f);
        Color color2 = new Color(96f / 255f, 224f / 255f, 96f / 255f);
        colorX = color1;
        colorY = color2;
        StartCoroutine(StartCube());

    }
    //Черный бэк
    void BlackBack()
    {    //black
       
        Hero.black = true;
        CountDown.text = "Black!";
        Color color5 = new Color(114f / 255f, 114f / 255f, 114f / 255f);
        Color color6 = new Color(51f / 255f, 51f / 255f, 51f / 255f);
        colorX = color5;
        colorY = color6;
        StartCoroutine(StartCube());

    }
    //красный бэк
    void RedBack()
    { //red
        Hero.red = true;
        CountDown.text = "Red!";
        Color color3 = new Color(188f / 255f, 3f / 255f, 42f / 255f);
        Color color4 = new Color(1, 1f / 255f, 55f / 255f);
        colorX = color3;
        colorY = color4;
        StartCoroutine(StartCube());
    }
    IEnumerator StartCube()
    {
        Hero.boom = true;
        yield return new WaitForSeconds(3);
        Hero.boom = false;
        SpawnCube.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
  


