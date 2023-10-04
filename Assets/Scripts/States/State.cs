using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract void StartState(BaseIA b);
    public abstract State RunCurrentState();
    public abstract void ExitState();
}
