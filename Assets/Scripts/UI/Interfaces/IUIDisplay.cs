using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIDisplay<T> 
{
    void Display(T displayItem);
    void Enable();
    void Disable();
}
