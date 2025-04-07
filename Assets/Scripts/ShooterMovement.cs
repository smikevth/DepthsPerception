using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterMovement : MonoBehaviour
{
    [SerializeField]
    GameData gameData;
    Vector2 moveInput = Vector2.zero;
    Vector3 movement = Vector3.zero;

    private void Awake()
    {
        gameData.OnGameActiveChange.AddListener(ClearMovement);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameData.IsGameActive)
        {
            MovePlayer();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(gameData.IsGameActive)
        {
            if(context.performed)
            {
                moveInput = context.ReadValue<Vector2>();
            }
            else
            {
                moveInput = Vector2.zero;
            }
        }
    }

    private void MovePlayer()
    {
        movement.z = moveInput.y;
        gameObject.transform.Translate(movement * gameData.ArcherSpeed);
        Vector3 pos = gameObject.transform.position;
        if (pos.z > gameData.ZRange)
        {
            gameObject.transform.position = new Vector3(pos.x, pos.y, gameData.ZRange);
        }
        else if (pos.z < -gameData.ZRange)
        {
            gameObject.transform.position = new Vector3(pos.x, pos.y, -gameData.ZRange);
        }
    }

    private void ClearMovement()
    {
        if(!gameData.IsGameActive)
        {
            moveInput = Vector2.zero;
        }
    }
}
