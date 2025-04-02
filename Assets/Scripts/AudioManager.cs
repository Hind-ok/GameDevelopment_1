using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----------Audio Sources------------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("-----------Audio Clips------------")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip checkpoint;
    public AudioClip bonus;
    public AudioClip KetFinish;
    public AudioClip NextLevel;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
