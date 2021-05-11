using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace IsSus.Game.Dialogue
{
    public class DialogueController : MonoBehaviour
    {
        #region Singleton
        public static DialogueController instance;
        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        #endregion

        public Conversation conversation;
        public GameObject leftCharacter;
        public GameObject rightCharacter;
        public float dialogueSpeed;

        private int dialogueIndex = 0;
        private DialogueUIDisplay leftUI;
        private DialogueUIDisplay rightUI;
        public GameObject dialogueWindow;
        public GameObject map;

        private void Start()
        {
            dialogueWindow.SetActive(true);
            rightCharacter.SetActive(false);
            leftUI = leftCharacter.GetComponent<DialogueUIDisplay>();
            rightUI = rightCharacter.GetComponent<DialogueUIDisplay>();

            leftUI.ActiveCharacter = conversation.individualLeft;
            rightUI.ActiveCharacter = conversation.individualRight;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                NextSentence();
            }
        }

        /// <summary>
        /// This function advances the conversation between the two characters
        /// </summary>
        public void NextSentence()
        {
            if(dialogueIndex < conversation.Lines.Length)
            {
                DisplayLine();
                dialogueIndex += 1;
            }
            else
            {
                leftUI.HideDialogue();
                rightUI.HideDialogue();
                dialogueWindow.SetActive(false);
                dialogueIndex = 0;
            }
        }

        /// <summary>
        /// This function calls the SelectDialogue function in order to determine the order of who is talking.
        /// </summary>
        public void DisplayLine()
        {
            Lines line = conversation.Lines[dialogueIndex];
            Individual individual = line.character;

            if(leftUI.CharacterIs(individual))
            {
                SelectDialogue(leftUI, rightUI, line.dialogueText);
            }
            else
            {
                SelectDialogue(rightUI, leftUI, line.dialogueText);
            }
        }

        /// <summary>
        /// This function displays the dialogue in an order of active and inactive.
        /// </summary>
        public void SelectDialogue(DialogueUIDisplay active, DialogueUIDisplay inactive, string dialogue)
        {
            active.Dialogue = dialogue;
            active.DisplayDialogue();
            inactive.HideDialogue();
        }
    }
}
