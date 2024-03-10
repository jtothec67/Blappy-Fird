using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    public GameObject Bird;
    public GameObject Pipe1;
    public GameObject Pipe2;
    public GameObject scoreCanvas;
    public GameObject endCanvas;
    [SerializeField] private TextMeshProUGUI ScoreNum;
    [SerializeField] private TextMeshProUGUI FinalScoreNum;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        score = 0;

        Time.timeScale = 1f;

        endCanvas.SetActive(false);
        scoreCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        FinalScoreNum.text = score.ToString();
        Time.timeScale = 0f;
        scoreCanvas.SetActive(false);
        endCanvas.SetActive(true);
    }

    public void GameRestart()
    {
        Time.timeScale = 1f;
        score = 0;
        ScoreNum.text = score.ToString();
        Bird.transform.position = new Vector3(0f,0f,0f);
        Pipe1.transform.position = new Vector3(5.6f, 0f, 0f);
        Pipe2.transform.position = new Vector3(11.2f, Random.Range(-2.5f, 3f), 0f);
        endCanvas.SetActive(false);
        scoreCanvas.SetActive(true);
    }

    public void UpdateScore()
    {
        score++;
        ScoreNum.text = score.ToString();
    }
}
