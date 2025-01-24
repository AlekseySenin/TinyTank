using System;

public interface IFactory<T>
{
    T Generate();

    Action<T> ActionOnGenerated { get; set; }
}