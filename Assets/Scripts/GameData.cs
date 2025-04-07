using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]
public class GameData : ScriptableObject
{
    [HideInInspector]
    public bool CanShoot = false;
    public float ZRange = 10.0f; //how far to move + and - on the z-axis
    public float ArcherSpeed = 0.5f; //How much to move each tick
    public float TargetSpeed = 0.3f; //How much to move each tick
    public float ArrowSpeed = 0.5f; //How fast the arrow moves
    public float ArrowRange = 10.0f; //When to destroy arrows that miss target
    public float MaxTime = 60.0f;
    [HideInInspector]
    public int HighScore = 0;
    [HideInInspector]
    public bool NewHighScore = false;

    [HideInInspector]
    public UnityEvent OnGameActiveChange;
    private bool isGameActive = false;
    public bool IsGameActive
    {
        get => isGameActive;
        set
        {
            isGameActive = value;
            OnGameActiveChange?.Invoke();
        }
    }

    [HideInInspector]
    public UnityEvent OnScoreChange;
    private int score = 0;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            OnScoreChange?.Invoke();
        }
    }

    

    [HideInInspector]
    public UnityEvent OnTimeChange;
    private float currentTime = 0;
    public float CurrentTime
    {
        get => currentTime;
        set
        {
            currentTime = value;
            OnTimeChange?.Invoke();
        }
    }
}
