using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] GameData gameData;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(gameData.ArrowSpeed, 0.0f, 0.0f), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameData.IsGameActive)
        {
            //move the arrow to the right
            //gameObject.transform.Translate(gameData.ArrowSpeed, 0.0f, 0.0f);
            
            //destroy off screen
            if(gameObject.transform.position.x >= gameData.ArrowRange)
            {
                RemoveArrow();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit something");
        if(other.CompareTag("Target"))
        {
            Debug.Log("hit target");
            //increment score and remove arrow on hit. add some hit feedback (particles/sfx) later
            gameData.Score++;
            RemoveArrow();
            
        }
    }

    private void RemoveArrow()
    {
        gameData.CanShoot = true;
        Destroy(gameObject);
    }
}
