using System;
using UnityEngine;

namespace GameAssets.Scripts.Player
{
    [Serializable]
    public class Player
    {
        [SerializeField] private string name;
        [SerializeField] private Role role;
        [SerializeField] private int voteCount = 0;
        [SerializeField] private string place;
        
        public Player(string name)
        {
            this.name = name;
            role = Role.CREWMATE;
            voteCount = 0;
            place = "";
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
        public string Place
        {
            get => place;
            set => place = value;
        }
    }
    public enum Role
    {
        CREWMATE,
        IMPOSTOR
    }
    
    
    
}
