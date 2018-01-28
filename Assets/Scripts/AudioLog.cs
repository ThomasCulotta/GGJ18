using UnityEngine;

public class AudioLog : MonoBehaviour
{
    public int LogNumber => _logNumber;

    [SerializeField]
    private int _logNumber = 0;
}
