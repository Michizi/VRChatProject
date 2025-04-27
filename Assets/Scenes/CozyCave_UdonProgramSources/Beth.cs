
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;



public class Beth : UdonSharpBehaviour
{
    public Animator animator;
    public float interval = 45f;
    public float yawn_interval = 15f;
    private float timer;
    private float yawn_timer;

    void Start()
    {
        animator = GetComponent<Animator>();
        timer = interval;
        yawn_timer = yawn_interval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        yawn_timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer = interval;
            animator.SetBool("Bored", true);
        }

        if (yawn_timer <= 0f && animator.GetBool("Bored"))
        {
            yawn_timer = yawn_interval;
            animator.SetTrigger("Yawn");
        }
        else if (yawn_timer <= 0f && !animator.GetBool("Bored"))
        {
            yawn_timer = yawn_interval;
        }
    }
}