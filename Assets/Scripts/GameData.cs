using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]
public class GameData : ScriptableObject
{
    public bool IsGameActive = false;
    public bool CanShoot = false;
    public float ZRange = 10.0f; //how far to move + and - on the z-axis
    public float ZInc = 0.3f; //How much to move each tick
    public float ArrowSpeed = 0.5f; //How fast the arrow moves
    public float ArrowRange = 10.0f; //When to destroy arrows that miss target

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
}
