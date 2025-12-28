
using UnityEditor;
using UnityEngine;
using System.IO;

public class BossBuilder {
    static string[] GetScenes() {
        var scenes = EditorBuildSettings.scenes;
        System.Collections.Generic.List<string> paths = new System.Collections.Generic.List<string>();
        foreach(var s in scenes) if(s.enabled) paths.Add(s.path);
        return paths.ToArray();
    }

    static void Setup() {
        PlayerSettings.companyName = "Shiro Games";
        PlayerSettings.productName = "Boss Raider";
        string iconPath = "Assets/BossIcon.png";
        if (File.Exists(iconPath)) {
            byte[] fileData = File.ReadAllBytes(iconPath);
            Texture2D tex = new Texture2D(2, 2); 
            tex.LoadImage(fileData);
            PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.Android, new Texture2D[] { tex, tex, tex, tex, tex, tex });
            PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.Unknown, new Texture2D[] { tex });
        }
        // Force Mono
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.Mono2x);
    }

    public static void BuildAll() {
        Setup();
        
        // Android
        BuildPlayerOptions opt = new BuildPlayerOptions();
        opt.scenes = GetScenes();
        opt.locationPathName = "Builds/Android/BossRaider.apk";
        opt.target = BuildTarget.Android;
        opt.options = BuildOptions.None;
        BuildPipeline.BuildPlayer(opt);

        // Windows
        opt.locationPathName = "Builds/Windows/BossRaider.exe";
        opt.target = BuildTarget.StandaloneWindows64;
        BuildPipeline.BuildPlayer(opt);
    }
}
    