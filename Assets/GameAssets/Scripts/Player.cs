using System;
using UnityEngine;

namespace GameAssets.Scripts
{
    [Serializable]
    public class Player
    {
        [SerializeField] private string name;
        private Role role;
        private int voteCount;
        public Player(string name, Role role, int voteCount)
        {
            this.name = name;
            this.role = role;
            this.voteCount = voteCount;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }
        public Role Role
        {
            get => role;
            set => role = value;
        }
        public int VoteCount
        {
            get => voteCount;
            set => voteCount = value;
        }
    }
    public enum Role
    {
        IMPOSTOR,
        CREWMATE
    }
    
    
}
