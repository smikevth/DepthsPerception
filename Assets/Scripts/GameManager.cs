using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameData gameData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameData.IsGameActive = true; //start game
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
