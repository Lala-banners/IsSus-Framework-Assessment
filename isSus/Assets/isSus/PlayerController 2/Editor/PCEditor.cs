using UnityEngine;
using UnityEditor;
using IsSus.Game.Controller;

namespace isSus.Game.Controller
{
    [CustomEditor(typeof(PlayerController))]
    public class PCEditor : Editor
    {
        private float labelW = 150f;

        public override void OnInspectorGUI()
        {
            // Call base class method
            base.DrawDefaultInspector();

            // Custom Inspector for Player Preferences
            PlayerController controller = (PlayerController) target; 

            GUILayout.Space(20f); 
            GUILayout.Label("Custom Editor Elements", EditorStyles.boldLabel); 

            GUILayout.Space(10f);
            GUILayout.Label("Player Preferences");

            GUILayout.BeginHorizontal(); 
            GUILayout.Label("Player Name", GUILayout.Width(labelW)); 
            controller.playerName = GUILayout.TextField(controller.playerName);
            GUILayout.EndHorizontal(); 

            GUILayout.BeginHorizontal();
            GUILayout.Label("Player Level", GUILayout.Width(labelW));
            controller.playerLevel = GUILayout.TextField(controller.playerLevel);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Player EXP", GUILayout.Width(labelW));
            controller.playerEXP = GUILayout.TextField(controller.playerEXP);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Player Score", GUILayout.Width(labelW));
            controller.playerScore = GUILayout.TextField(controller.playerScore);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            //Save the player choices
            if (GUILayout.Button("Save")) 
            {
                PlayerPrefs.SetString("PlayerName", controller.playerName); 
                PlayerPrefs.SetString("PlayerLevel", controller.playerLevel);
                PlayerPrefs.SetString("PlayerEXP", controller.playerEXP);
                PlayerPrefs.SetString("PlayerScore", controller.playerScore);

                Debug.Log("PlayerPrefs Saved");
            }

            if (GUILayout.Button("Reset")) 
            {
                PlayerPrefs.DeleteAll();
                Debug.Log("PlayerPrefs Reset");
            }
            GUILayout.EndHorizontal();
        }
    }
}
