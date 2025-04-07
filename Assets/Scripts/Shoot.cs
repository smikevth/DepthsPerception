using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameData gameData;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] AudioManager audioManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if(context.performed && gameData.IsGameActive && gameData.CanShoot)
        {
            gameData.CanShoot = false;
            Instantiate(arrowPrefab, gameObject.transform.position, arrowPrefab.transform.rotation);
            audioManager.PlaySound("Shoot");
        }
    }
}
