using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float leftPadding;
    [SerializeField] float rightPadding;
    [SerializeField] float upPadding;
    [SerializeField] float downPadding;
    Shooter shooter;
    Vector2 input;
    Vector2 minBounds;
    Vector2 maxBounds;

    private void Awake() {
        shooter = GetComponent<Shooter>();
    }

    private void Start() {
        InitBounds();
    }

    private void Update()
    {
        ProcessMoving();
    }

    void InitBounds() {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void ProcessMoving()
    {
        Vector2 newOffset = input * Time.deltaTime * movementSpeed;
        newOffset.x = Mathf.Clamp(transform.position.x + newOffset.x, minBounds.x + leftPadding, maxBounds.x - rightPadding);
        newOffset.y = Mathf.Clamp(transform.position.y + newOffset.y, minBounds.y + downPadding, maxBounds.y - upPadding);
        transform.position = newOffset;
    }

    void OnMove(InputValue value) {
        input = value.Get<Vector2>();
    }

    void OnFire(InputValue value) {
        if(shooter == null) {return;}

        shooter.SetIsFiring(value.isPressed);
    }
}
