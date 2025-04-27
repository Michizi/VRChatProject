
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MusicManager : UdonSharpBehaviour
{
    [SerializeField] public AudioClip[] musicTracks; 
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator beth;
    private int currentTrackIndex = 0;

    void Start()
    {
        PlayTrack(currentTrackIndex);
    }

    public void PlayTrack(int trackIndex)
    {
        if (trackIndex >= 0 && trackIndex < musicTracks.Length)
        {
            currentTrackIndex = trackIndex;
            audioSource.clip = musicTracks[trackIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Track index out of range!");
        }
        beth.SetBool("Bored",false);
    }

    public void PlayNextTrack()
    {
        currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;
        PlayTrack(currentTrackIndex);
    }


}