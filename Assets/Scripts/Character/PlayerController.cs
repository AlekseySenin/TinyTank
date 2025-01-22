using Zenject;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : TankController
{
    [Inject] private PlayerInputActions inputActions;
    [Inject] TankConfig _tankConfig;
    [Inject] TankGun _tankGun;

    private float _turnSpeed;
    private float _moveSpeed;
    private void OnEnable()
    {
        if (inputActions != null)
        {
            inputActions.DefaultGameMap.Enable();
            inputActions.DefaultGameMap.Shoot.performed += Shoot;
            inputActions.DefaultGameMap.TurnLeft.performed += TurnLeft;
            inputActions.DefaultGameMap.TurnRight.performed += TurnRight;
            inputActions.DefaultGameMap.MoveForward.performed += MoveForward;
            inputActions.DefaultGameMap.MoveBackward.performed += MoveBackward;
        }
        else
        {
            Debug.LogWarning("inputActions == null!");
        }
    }


    private void OnDisable()
    {
        inputActions.DefaultGameMap.Shoot.performed -= Shoot;
        inputActions.DefaultGameMap.TurnLeft.performed -= TurnLeft;
        inputActions.DefaultGameMap.TurnRight.performed -= TurnRight;
        inputActions.DefaultGameMap.MoveForward.performed -= MoveForward;
        inputActions.DefaultGameMap.MoveBackward.performed -= MoveBackward;
    }

    private void FixedUpdate()
    {
        TryTurn();
        TryMove();
    }

    private void TryTurn()
    {
        if (inputActions.DefaultGameMap.TurnLeft.inProgress && inputActions.DefaultGameMap.TurnRight.inProgress)
        {
            _tankMover.Turn(_turnSpeed);
            return;
        }
        if (inputActions.DefaultGameMap.TurnLeft.inProgress)

        {
            _turnSpeed = -_tankConfig.TurnSpeed;
            _tankMover.Turn(_turnSpeed);
            return;
        }

        if (inputActions.DefaultGameMap.TurnRight.inProgress)
        {
            _turnSpeed = _tankConfig.TurnSpeed;
            _tankMover.Turn(_turnSpeed);
            return;
        }
    }

    private void TryMove()
    {
        if (inputActions.DefaultGameMap.MoveForward.inProgress && inputActions.DefaultGameMap.MoveBackward.inProgress)
        {
            _tankMover.Move(_moveSpeed);
            return;
        }
        if (inputActions.DefaultGameMap.MoveForward.inProgress) 
        {
            _moveSpeed = _tankConfig.MoveForvardSpeed;
            _tankMover.Move(_moveSpeed);
            return;

        }

        if (inputActions.DefaultGameMap.MoveBackward.inProgress) 
        {
            _moveSpeed = -_tankConfig.MoveBackvardSpeed;
            _tankMover.Move(_moveSpeed);
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

    void TurnLeft(InputAction.CallbackContext context)
    {
        _turnSpeed = -_tankConfig.TurnSpeed;
    }
    void TurnRight(InputAction.CallbackContext context)
    {
        _turnSpeed = _tankConfig.TurnSpeed;
    }
    void MoveForward(InputAction.CallbackContext context)
    {
        _moveSpeed = _tankConfig.MoveForvardSpeed;
    }
    void MoveBackward(InputAction.CallbackContext context)
    {
        _moveSpeed = _tankConfig.MoveBackvardSpeed;

    }
}
