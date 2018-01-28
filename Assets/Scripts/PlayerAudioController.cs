using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioLogSource;

    [SerializeField]
    private AudioClip[] _audioLogs;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("AudioLog"))
        {
            _audioLogSource.clip = _audioLogs[other.GetComponent<AudioLog>().LogNumber];
            _audioLogSource.Play(1);
        }
    }
}
