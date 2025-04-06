using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameData gameData;
    [SerializeField] GameObject target;
    Vector3 targetPos = new Vector3(); //position of target (just need x,y)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        gameData.OnScoreChange.AddListener(MoveTarget);
    }
    void Start()
    {
        targetPos = target.transform.position;
        ResetGameData();
        StartGame();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameData.IsGameActive)
        {
            gameData.CurrentTime -= Time.deltaTime;
            if(gameData.CurrentTime <= 0.0f)
            {
                EndGame();
            }
        }
    }

    //move target when the score changes (i.e. target was hit)
    void MoveTarget()
    {
        if(gameData.IsGameActive)
        {
            float randZ = Random.Range(-gameData.ZRange, gameData.ZRange);
            target.transform.position = new Vector3(targetPos.x, targetPos.y, randZ);
        }
    }

    void EndGame()
    {
        gameData.IsGameActive = false;
        GameObject[] arrows = GameObject.FindGameObjectsWithTag("Arrow");
        foreach(GameObject arrow in arrows)
        {
            Destroy(arrow);
        }
        Debug.Log("Game over");
    }

    void ResetGameData()
    {
        gameData.Score = 0;
        gameData.CurrentTime = gameData.MaxTime;
    }

    void StartGame()
    {
        gameData.IsGameActive = true;
        gameData.CanShoot = true;
    }

    public void RestartGame()
    {
        ResetGameData();
        StartGame();
    }
}
