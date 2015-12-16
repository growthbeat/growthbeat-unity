using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

public class BuildPostProcessor
{
    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget target, string xcodeProjectPath)
    {
        if (target == BuildTarget.iOS)
        {
            AddUrlScheme(xcodeProjectPath, "growth-sample");
            AddGrowthbeatDependencyFramework (xcodeProjectPath);
        }
    }

    private static void AddUrlScheme(string xcodeProjectPath, string scheme)
    {
        var plistPath = Path.Combine(xcodeProjectPath, "Info.plist");
        var info = File.ReadAllText(plistPath);
        var beforeText = "<plist version=\"1.0\">\n<dict>";
        var afterText = string.Format("<plist version=\"1.0\">\n<dict>\n<key>CFBundleURLTypes</key><array><dict><key>CFBundleURLSchemes</key><array><string>{0}</string></array></dict></array>", scheme);

        info = info.Replace(beforeText, afterText);
        File.WriteAllText(plistPath, info);
    }

    private static void AddGrowthbeatDependencyFramework (string path)
    {
        string projectPath = PBXProject.GetPBXProjectPath(path);
        PBXProject pbxProject = new PBXProject();
        
        pbxProject.ReadFromString(File.ReadAllText(projectPath));
        string target = pbxProject.TargetGuidByName("Unity-iPhone");
        
        pbxProject.AddFrameworkToProject(target, "AdSupport.framework", false);
        pbxProject.AddFrameworkToProject(target, "SafariServices.framework", false);
        pbxProject.AddFrameworkToProject(target, "Security.framework", false);
    
        File.WriteAllText(projectPath, pbxProject.WriteToString());
    }

}