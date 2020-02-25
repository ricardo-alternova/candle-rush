using UnityEngine;

public interface IInput
{
    Vector2 MoveDirection();
    bool AcceptButton();
    bool CancelButton();
    bool BackButton();
}
