using UnityEngine;

public class AudioLog : MonoBehaviour
{
    [HideInInspector]
    public bool CanPlay = true;

    public int LogNumber => _logNumber;

    [SerializeField]
    private int _logNumber = 0;
}
