using UnityEngine;

public class FadeScript : MonoBehaviour
{
    [SerializeField]
    private string _levelToLoad;

    private void OnTriggerEnter()
    {
        SteamVR_Fade.Start(Color.black, 2f);
        SteamVR_LoadLevel.Begin(_levelToLoad, fadeOutTime: 2f);
	}
}
