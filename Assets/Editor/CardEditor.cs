using UnityEngine;
using UnityEditor;

public class CardEditor : EditorWindow {

    string name = "Card Name";
    string description = "Card Description";
    Sprite fgArtwork;
    Sprite bgArtwork;
    int range = 1;
    int damage = 1;
    CombatState combatState;
    TargetType targetType;

    [MenuItem("Window/Card Editor")]
    public static void ShowWindow()
    {
        GetWindow<CardEditor>("Card Editor");
    }

    private void OnGUI()
    {
        GUILayout.Label("Create A New Card", EditorStyles.boldLabel);
        name = EditorGUILayout.TextField("Name", name);
        description = EditorGUILayout.TagField("Description", description);
       

        if (GUILayout.Button("Create Card"))
        {
            //Create Card
        }
    }

}
