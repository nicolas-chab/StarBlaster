using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    InputAction moveAction;
    Vector2 minBounds;
    Vector2 maxBounds;
    Vector3 moveVector;
    [SerializeField] float moveSpeed=10f;
    [SerializeField] float leftBoundPadding;
    [SerializeField] float rightBoundPadding;
    [SerializeField] float DownBoundPadding;
    [SerializeField] float upBoundPadding;
    Shooter playerShooter;
    InputAction fireAction;
    void Start()
    {
        playerShooter=GetComponent<Shooter>();

        moveAction=InputSystem.actions.FindAction("Move");
        fireAction=InputSystem.actions.FindAction("Fire");
        initBounds();
    }

    void Update()
    {
        MovePlayer();
        FireShooter();
    }
    void initBounds()
    {
        Camera mainCamera=Camera.main;
        minBounds=mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds=mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }
    void MovePlayer()
    {
        moveVector=moveAction.ReadValue<Vector2>();

        Vector3 newPos=transform.position  + moveVector*moveSpeed*Time.deltaTime;

        newPos.x=math.clamp(newPos.x,minBounds.x +leftBoundPadding,maxBounds.x-rightBoundPadding);
        newPos.y=math.clamp(newPos.y,minBounds.y+DownBoundPadding ,maxBounds.y-upBoundPadding);

        transform.position = newPos;
    }
    void FireShooter()
    {
        playerShooter.isFiring=fireAction.IsPressed();
    }
}
