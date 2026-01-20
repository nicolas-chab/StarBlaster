using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("shooting sfx")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] AudioClip takedamageClip;
    [Header("damage sfx")]
    [SerializeField][Range(0,1)] float shootingVolume;
    [SerializeField][Range(0,1)] float takedamageVolume;
    
    public void PlayShootingSFX()
    {
        PlayAudioClip(shootingClip,shootingVolume);
    }
    public void PlayDamageSFX()
    {
        if(takedamageClip != null)
        {
            PlayAudioClip(takedamageClip,takedamageVolume);
        }
    }
    void PlayAudioClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position,volume);
        }
    }
}
