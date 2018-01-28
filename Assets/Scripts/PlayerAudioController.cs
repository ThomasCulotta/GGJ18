
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioLogIntroSource;
    
    [SerializeField]
    private AudioSource _audioLogSource;

    [SerializeField]
    private AudioClip[] _audioLogs;

    private int _logCounter;

    private void Awake()
    {
        _logCounter = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("AudioLog"))
        {
            AudioLog audioLog = other.GetComponent<AudioLog>();
            if (audioLog.CanPlay)
            {
                audioLog.CanPlay = false;
                Destroy(other.gameObject);
                _audioLogSource.clip = _audioLogs[_logCounter++];
                _audioLogIntroSource.Play();
                _audioLogSource.PlayDelayed(_audioLogIntroSource.clip.length);
            }
        }
    }
}
