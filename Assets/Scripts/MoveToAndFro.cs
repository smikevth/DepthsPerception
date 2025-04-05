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
        if(gameData.IsGameActive)
        {
            //if game is going, move the object back and forth on the z-axis
            gameObject.transform.Translate(direction * gameData.ZInc);

            if(Mathf.Abs(gameObject.transform.position.z) >= gameData.ZRange)
            {
                //flip direction at end of range
                direction *= -1;
            }
            
        }
    }
}
