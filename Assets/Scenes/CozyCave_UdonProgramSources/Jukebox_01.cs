
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Jukebox_01 : UdonSharpBehaviour
{
    [SerializeField] public MusicManager musicManager;

    public override void Interact()
    {
        if (musicManager != null)
            musicManager.PlayNextTrack();
    }
}