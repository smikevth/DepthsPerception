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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        gameData.OnScoreChange.AddListener(UpdateScore);
        gameData.OnTimeChange.AddListener(UpdateTime);
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
}
