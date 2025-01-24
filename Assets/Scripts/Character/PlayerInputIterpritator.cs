using Zenject;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputIterpritator : MonoBehaviour
{

    [Inject] private PlayerInputActions inputActions;
    [Inject] TankConfig _tankConfig;
    [Inject] TankGun _tankGun;
    [Inject] protected ITankMover _tankMover;

    private bool _isMoveFront;
    private bool _isTurnRight;
    private void OnEnable()
    {
        if (inputActions != null)
        {
            inputActions.DefaultGameMap.Enable();
            inputActions.DefaultGameMap.Shoot.performed += Shoot;
            inputActions.DefaultGameMap.TurnLeft.performed += TurnLeftResponce;
            inputActions.DefaultGameMap.TurnRight.performed += TurnRightResponce;
            inputActions.DefaultGameMap.MoveForward.performed += MoveForwardResponce;
            inputActions.DefaultGameMap.MoveBackward.performed += MResponceoveBackward;
        }
        else
        {
            Debug.LogWarning("inputActions == null!");
        }
    }
    private void OnDisable()
    {
        inputActions.DefaultGameMap.Shoot.performed -= Shoot;
        inputActions.DefaultGameMap.TurnLeft.performed -= TurnLeftResponce;
        inputActions.DefaultGameMap.TurnRight.performed -= TurnRightResponce;
        inputActions.DefaultGameMap.MoveForward.performed -= MoveForwardResponce;
        inputActions.DefaultGameMap.MoveBackward.performed -= MResponceoveBackward;
    }

    private void FixedUpdate()
    {
        TryTurn();
        TryMove();
    }

    private void TryTurn()
    {
        bool bothButtonsArePressed = inputActions.DefaultGameMap.TurnLeft.inProgress && inputActions.DefaultGameMap.TurnRight.inProgress;
        if (bothButtonsArePressed)
        {
            //turn in last selected direction
            Turn();
            return;
        }
        bool turnLeftIsPressed = inputActions.DefaultGameMap.TurnLeft.inProgress;
        if (turnLeftIsPressed)

        {
            _tankMover.TurnLeft();
            return;
        }
        bool TurnRightIsPressed = inputActions.DefaultGameMap.TurnRight.inProgress;
        if (TurnRightIsPressed)
        {
            _tankMover.TurnRight();
            return;
        }
    }

    public void TryMove()
    {
        bool bothButtonsArePressed = inputActions.DefaultGameMap.MoveForward.inProgress && inputActions.DefaultGameMap.MoveBackward.inProgress;

        if (bothButtonsArePressed)
        {
            //move in last selected direction
            Move();
            return;
        }
        bool moveFwIsPressed = inputActions.DefaultGameMap.MoveForward.inProgress;
        if (moveFwIsPressed) 
        {
            _tankMover.MoveFront();
            return;

        }
        bool moveBackIsPressed = inputActions.DefaultGameMap.MoveBackward.inProgress;
        if (moveBackIsPressed) 
        {
            _tankMover.MoveRare();
            return;
        }
    }


    void Shoot(InputAction.CallbackContext context)
    {
        ShootAsync();
    }
    private async void ShootAsync()
    {
        await _tankGun.Shoot();
    }
    
    void TurnLeftResponce(InputAction.CallbackContext context)
    {
        _isTurnRight = false;
    }
    void TurnRightResponce(InputAction.CallbackContext context)
    {
        _isTurnRight = true;
    }
    void MoveForwardResponce(InputAction.CallbackContext context)
    {
        _isMoveFront = true;
    }
    void MResponceoveBackward(InputAction.CallbackContext context)
    {
        _isMoveFront = false;
    }
    void Move ()
    {
        if (_isMoveFront)
        {
            _tankMover.MoveFront();
        }
        else
        {
            _tankMover.MoveRare();
        }
    }

    void Turn()
    {
        if (_isTurnRight)
        {
            _tankMover.TurnRight();
        }
        else
        {
            _tankMover.TurnLeft();
        }
    }
}
