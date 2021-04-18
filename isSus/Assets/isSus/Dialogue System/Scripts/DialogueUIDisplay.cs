using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace IsSus.Game.Dialogue 
{
    public class DialogueUIDisplay : MonoBehaviour
    {
        public Image icon;
        public TextMeshProUGUI individualName;
        public TextMeshProUGUI dialogueText;
        private Individual character;

        /// <summary>
        /// Active Speaking Character to UI elements for display.
        /// </summary>
        public Individual ActiveCharacter
        {
            get { return character; }

            set { character = value;
                icon.sprite = character.Face;
                individualName.text = character.individualName;
            }
        }

        public string Dialogue
        {
            set { dialogueText.text = value; }
        }

        public bool HasSpoken()
        {
            return character != null;
        }

        public bool CharacterIs(Individual _character)
        {
            return _character == character;
        }

        public void DisplayDialogue()
        {
            gameObject.SetActive(true);
        }

        public void HideDialogue()
        {
            gameObject.SetActive(false);
        }
    }
}
