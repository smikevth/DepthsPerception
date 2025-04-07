using UnityEngine;

public class MoveToAndFro : MonoBehaviour
{
    [SerializeField] GameData gameData;

    Vector3 direction = new Vector3(0.0f, 0.0f, 1.0f); //flip to negative to change direction

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if game is going, move the object back and forth on the z-axis (starting after 7 hits)
        if (gameData.IsGameActive && gameData.Score >= 7)
        {
            //increase speed after 14 hits
            float speedF = 1.0f;
            if(gameData.Score > 14)
            {
                speedF = (gameData.Score - 14.0f) / 6.6f + 1.0f;
            }
            Debug.Log(speedF);
            
            gameObject.transform.Translate(direction * gameData.TargetSpeed * speedF);

            if(Mathf.Abs(gameObject.transform.position.z) >= gameData.ZRange)
            {
                //flip direction at end of range
                direction *= -1;
            }
            
        }
    }
}
