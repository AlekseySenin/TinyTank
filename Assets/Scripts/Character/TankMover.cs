using Zenject;
using UnityEngine;

public class TankMover 
{
    private Rigidbody _rigidbody;
    [Inject]
    public TankMover(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
    }

    public void Move(float speed)
    {
        Vector3 directForce = _rigidbody.transform.forward * speed;
        _rigidbody.velocity = directForce;
        //_rigidbody.AddForce(directForce, ForceMode.Acceleration);
    }
    public void Turn(float speed)
    {
        _rigidbody.transform.Rotate(0,speed,0);
    } 
}
