using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] GameData gameData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameData.IsGameActive)
        {
            //move the arrow to the right
            gameObject.transform.Translate(gameData.ArrowSpeed, 0.0f, 0.0f);
            //destroy off screen
            if(gameObject.transform.position.x >= gameData.ArrowRange)
            {
                gameData.CanShoot = true;
                Destroy(gameObject);
            }
        }
    }
}
