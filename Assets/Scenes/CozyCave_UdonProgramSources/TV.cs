
using UdonSharp;
using UnityEngine;
using UnityEngine.Video;
using VRC.SDK3.Video.Components;
using VRC.SDKBase;
using VRC.Udon;

public class TV : UdonSharpBehaviour
{
    public VRCUnityVideoPlayer video;

    public override void Interact()
    {
        video.Play();
    }
}
