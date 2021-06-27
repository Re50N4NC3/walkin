using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour{
    private InputSystem inputSystem;

    public Vector2 mousePosition;
    public Vector2 projectedMousePosition;

    private void Awake() {
        inputSystem = new InputSystem();

    }
 
    void Update(){
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
}
