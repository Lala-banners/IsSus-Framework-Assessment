using UnityEngine;
using System;

namespace IsSus.Game.Dialogue
{
    [Serializable]
    public struct Lines //What will be in each line of dialogue
    {
        public Individual character;
        [TextArea] public string dialogueText;
    }

    [CreateAssetMenu(menuName = "isSus/Dialogue/Conversation", fileName = "New Conversation")]
    public class Conversation : ScriptableObject
    {
        public Individual individualLeft;
        public Individual individualRight;

        [SerializeField] private Lines[] dialogueLines;
        public Lines[] Lines => dialogueLines;
    }
}
