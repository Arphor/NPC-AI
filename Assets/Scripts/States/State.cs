using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract void StartState(BaseIA baseIA);
    public abstract void RunCurrentState();
    public abstract void ExitState();
}
