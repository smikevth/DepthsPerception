using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameData gameData;
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI timeText;
    [SerializeField]
    GameObject GameOverScreen;
    [SerializeField]
    TextMeshProUGUI finalScoreText;
    [SerializeReference]
    GameObject newHighScore;
    [SerializeReference]
    GameObject oldHighScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        gameData.OnScoreChange.AddListener(UpdateScore);
        gameData.OnTimeChange.AddListener(UpdateTime);
        gameData.OnGameActiveChange.AddListener(ShowHideGameOver);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + gameData.Score;
    }

    private void UpdateTime()
    {
        timeText.text = gameData.CurrentTime.ToString("F1");
    }

    private void ShowHideGameOver()
    {
        GameOverScreen.SetActive(!gameData.IsGameActive);
        if(!gameData.IsGameActive)
        {
            finalScoreText.text = "You hit " + gameData.Score + " targets!";
            if(gameData.NewHighScore)
            {
                gameData.NewHighScore = false;
                newHighScore.SetActive(true);
                oldHighScore.SetActive(false);
            }
            else
            {
                newHighScore.SetActive(false);
                oldHighScore.SetActive(true);
                oldHighScore.GetComponent<TextMeshProUGUI>().text = "High Score: " + gameData.HighScore;
            }
        }
    }
}
