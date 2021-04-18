using UnityEngine;
using UnityEngine.UI;

namespace IsSus.Game.Dialogue
{
    [CreateAssetMenu(menuName = "isSus/Dialogue/Individual", fileName = "New Individual")]
    public class Individual : ScriptableObject
    {
        [SerializeField] private Sprite sprite;
        public Sprite Face => sprite; //Face window to display who is speaking
        public string individualName;
    }
}
