
using UdonSharp;
using UnityEngine;
using UnityEngine.Video;
using VRC.SDKBase;
using VRC.Udon;

public class Remote : UdonSharpBehaviour
{
    [SerializeField] public VideoPlayer video;
    private bool state = false;

    public override void Interact()
    {
        if (state)
        {
            video.Stop();
            state = false;
        }
        else
        {
            video.Play();
            state = true;
        }
    }
}
