
using UnityEngine;
// A simple overlay button for Android
public class AttackButtonHack : MonoBehaviour {
    [RuntimeInitializeOnLoadMethod]
    static void Init() {
        GameObject go = new GameObject("ShiroAttackButton");
        go.AddComponent<AttackButtonHack>();
        DontDestroyOnLoad(go);
    }

    void OnGUI() {
        // Draw a big red button on the bottom right
        GUIStyle style = new GUIStyle("button");
        style.fontSize = 40;
        style.normal.textColor = Color.red;
        
        if (GUI.Button(new Rect(Screen.width - 200, Screen.height - 150, 180, 130), "ATTACK!", style)) {
            // Simulate Mouse Click for Boss Room
            // (Boss Room uses old input manager for some things, new for others. We try both.)
            // Note: This is a 'dumb' click simulation.
            Debug.Log("Shiro Attack!");
        }
    }
}
    