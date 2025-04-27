
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;



public class Bob : UdonSharpBehaviour
{
    public Animator animator;
    public float interval = 15f;
    private float timer;
    private bool hasSeenPlayer = false;
    private VRCPlayerApi localPlayer;

    void Start()
    {
        animator = GetComponent<Animator>();
        timer = interval;
        localPlayer = Networking.LocalPlayer;
    }

    void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer = interval;
            animator.SetTrigger("Bartending");

        }

        if (!hasSeenPlayer && localPlayer != null)
        {
            float distance = Vector3.Distance(transform.position, localPlayer.GetPosition());

            if (distance < 10f) // Detection range
            {
                Vector3 directionToPlayer = (localPlayer.GetPosition() - transform.position).normalized;
                float angle = Vector3.Angle(transform.forward, directionToPlayer);

                if (angle < 45f) // Field of view (45 degrees)
                {
                    if (!Physics.Linecast(transform.position, localPlayer.GetPosition(), LayerMask.GetMask("Obstacles")))
                    {
                        TriggerDetection();
                    }
                }
            }
        }
    }

    void TriggerDetection()
    {
        hasSeenPlayer = true;
        animator.SetTrigger("Wave");
    }

}