using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameData gameData;
    [SerializeField] GameObject target;
    Vector3 targetPos = new Vector3(); //position of target (just need x,y)
    [SerializeField] AudioManager audioManager;
    [SerializeField] GameObject hitPFXPrefab;
    private float pfxTime = 0.3f;

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
        if(gameData.Score != 0)
        {
            audioManager.PlaySound("Hit");
            GameObject pfx = Instantiate(hitPFXPrefab, target.transform.position, hitPFXPrefab.transform.rotation);
            StartCoroutine(DelayedDestroy(pfx, pfxTime));
        }
        float randZ = Random.Range(-gameData.ZRange, gameData.ZRange);
        target.transform.position = new Vector3(targetPos.x, targetPos.y, randZ);
    }

    void EndGame()
    {
        if(gameData.Score > gameData.HighScore)
        {
            gameData.HighScore = gameData.Score;
            gameData.NewHighScore = true;
        }
        gameData.IsGameActive = false;
        GameObject[] arrows = GameObject.FindGameObjectsWithTag("Arrow");
        foreach(GameObject arrow in arrows)
        {
            Destroy(arrow);
        }

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

    IEnumerator DelayedDestroy(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
}
