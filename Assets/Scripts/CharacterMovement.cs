using UnityEngine;

public class CharacterMovement : MonoBehaviour{
    public Pseudo3DController pseudo3DController;
    public MouseController mouseController;

    private InputSystem inputSystem;
    private Rigidbody2D rb;
    
    public bool isControlled = true;
    bool tryingToMove = false;

    public float maxSpeed = 8.0f;
    public float acceleration = 0.4f;
    public float inertia = 2;

    public float velX = 0;
    public float velY = 0;
    Vector2 direction;

    private void Awake() {
        inputSystem = new InputSystem();
        rb = GetComponent<Rigidbody2D>();
    }

    #region Input Enable/Disable
    private void OnEnable() {
        inputSystem.Enable();
    }

    private void OnDisable() {
        inputSystem.Disable();
    }
    #endregion
    
    private void FixedUpdate() {
        Move();
    }

    private void Update() {
        GetControllerValues();
        ChangeSpeed();
    }

    void GetControllerValues(){
        if (isControlled){
            // get movement direction
            direction = inputSystem.Player.Move.ReadValue<Vector2>();

            if (inputSystem.Player.Move.ReadValue<Vector2>().magnitude != 0){
                tryingToMove = true;
            }
            else{
                tryingToMove = false;
            }

            // apply direction from mouse position
            pseudo3DController.lookPoint = mouseController.mousePosition - new Vector2(transform.position.x, transform.position.y);
        }

    }

    void ChangeSpeed(){
        // increase speed over time
        velX = SpeedLogic(direction.x, velX);
        velY = SpeedLogic(direction.y, velY);
    }

    float SpeedLogic(float directionToMove, float speedValue){
        if (directionToMove != 0 && tryingToMove){
            speedValue += acceleration * directionToMove;
            speedValue = Mathf.Clamp(speedValue, -maxSpeed, maxSpeed);
        }
        else{
            speedValue = Mathf.Lerp(speedValue, 0, Time.deltaTime * inertia);
        }

        return speedValue;
    }

    void Move(){
        Vector2 movementVector = new Vector2(velX, velY);
        rb.velocity = movementVector;
    }
}