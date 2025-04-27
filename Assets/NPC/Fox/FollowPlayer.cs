using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

using UnityEngine.AI;

namespace SimpleAI
{
    public class FollowPlayer : UdonSharpBehaviour
    {
        [Header("Player-chasing AI!")][Space] private NavMeshAgent Agent; // AI's agent
        private VRCPlayerApi TargetPlayer; // The target player

        private void Start()
        {
            // Assign variables
            Agent = GetComponent<NavMeshAgent>();
            TargetPlayer = Networking.LocalPlayer;
        }

        private void Update()
        {
            // Set's the AIs target position every update loop to the players current root position!
            Agent.SetDestination(TargetPlayer.GetPosition());
        }

    }
}