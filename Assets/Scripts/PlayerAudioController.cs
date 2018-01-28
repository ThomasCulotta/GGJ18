
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioLogIntroSource;
    
    [SerializeField]
    private AudioSource _audioLogSource;

    [SerializeField]
    private AudioClip[] _audioLogs;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("AudioLog"))
        {
            AudioLog audioLog = other.GetComponent<AudioLog>();
            if (audioLog.CanPlay)
            {
                audioLog.CanPlay = false;
                _audioLogSource.clip = _audioLogs[audioLog.LogNumber];
                _audioLogIntroSource.Play();
                _audioLogSource.PlayDelayed(_audioLogIntroSource.clip.length);
            }
        }
    }
}
