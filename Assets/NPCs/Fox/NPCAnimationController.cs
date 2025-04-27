using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class NPCAnimationController : UdonSharpBehaviour
{
    public Animator animator;
    public float movementThreshold = 0.01f;

    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        float movementSpeed = (currentPosition - lastPosition).magnitude / Time.deltaTime;

        bool isWalking = movementSpeed > movementThreshold;
        animator.SetBool("IsWalking", isWalking);

        lastPosition = currentPosition;
    }
}
