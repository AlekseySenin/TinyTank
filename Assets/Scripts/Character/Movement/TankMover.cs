using Zenject;
using UnityEngine;

public class TankMover : ITankMover
{
    private Rigidbody _rigidbody;
    private TankConfig _tankConfig;
    [Inject]
    public TankMover(Rigidbody rigidbody, TankConfig tankConfig)
    {
        _rigidbody = rigidbody;
        _tankConfig = tankConfig;
    }

    public void MoveFront()
    {
        Move(_tankConfig.MoveForvardSpeed);
    }

    public void MoveRare()
    {
        Move(-_tankConfig.MoveBackvardSpeed);
    }

    public void TurnLeft()
    {
        Turn(-_tankConfig.TurnSpeed);
    }

    public void TurnRight()
    {
        Turn(_tankConfig.TurnSpeed);
    }

    public void Move(float speed)
    {
        Vector3 directForce = _rigidbody.transform.forward * speed;
        _rigidbody.velocity = directForce;
    }
    public void Turn(float speed)
    {
        _rigidbody.transform.Rotate(0,speed,0);
    } 
}
