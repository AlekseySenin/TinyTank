using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/TankConfig")]
public class TankConfig : ScriptableObject
{
    public float MoveForvardSpeed;
    public float MoveBackvardSpeed;
    public float TurnSpeed;
}
