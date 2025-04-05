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
        gameData.IsGameActive = true; //start game
        gameData.CanShoot = true;
        gameData.Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
