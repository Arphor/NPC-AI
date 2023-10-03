using UnityEngine;

public class PathPosition : MonoBehaviour
{
    public Vector3 position;
    [SerializeField] private bool isIdlePosition;
    

    private void Start()
    {
        position = this.transform.position;
    }

    public bool IsIdlePosition()
    {
        return isIdlePosition;
    }
}