using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]
public class GameData : ScriptableObject
{
    public bool IsGameActive = false;
    public float zRange = 10.0f; //how far to move + and - on the z-axis
    public float zInc = 0.3f; //How much to move each tick
}
