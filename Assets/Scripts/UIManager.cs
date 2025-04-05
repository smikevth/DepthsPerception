using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameData gameData;
    [SerializeField]
    TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        gameData.OnScoreChange.AddListener(UpdateScore);
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
}
