using Zenject;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [Inject] protected TankMover _tankMover;
}
