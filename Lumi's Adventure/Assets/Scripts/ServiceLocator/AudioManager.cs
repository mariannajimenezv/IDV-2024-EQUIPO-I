using UnityEngine;

public class AudioManager : MonoBehaviour, IAudioService
{
    public void PlaySound(string soundId)
    {
        Debug.Log($"Playing sound: {soundId}");
    }

    public void StopSound(string soundId)
    {
        Debug.Log($"Stopping sound: {soundId}");
    }

    private void Awake()
    {
        ServiceLocator.Register<IAudioService>(this);
    }
}
