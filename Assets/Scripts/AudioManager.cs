using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("shooting sfx")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] AudioClip takedamageClip;
    [Header("damage sfx")]
    [SerializeField][Range(0,1)] float shootingVolume;
    [SerializeField][Range(0,1)] float takedamageVolume;

    static AudioManager instance;


    void Awake()
    {
        ManageSingleton();
    }
    void ManageSingleton()
    {
        //int instanceCount=FindObjectsByType<AudioManager>(FindObjectsSortMode.None).Length;
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
    }
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
