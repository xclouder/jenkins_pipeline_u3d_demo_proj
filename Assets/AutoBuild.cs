using UnityEngine;
using UnityEditor;

public class AutoBuild
{
	public void BuildAPK()
	{
		PlayerSettings.bundleIdentifier = "com.xclouder.demo";
        PlayerSettings.productName = "pipelinedemo";

        BuildPipeline.BuildPlayer(GetScenes(), m_outPath, BuildTarget.Android, BuildOptions.None);
	}

	string[] GetScenes()
	{
		var scenes = new List<string>();

        foreach (var scene in EditorBuildSettings.scenes)
        {
            if (scene == null)
                continue;
            if (scene.enabled)
                scenes.Add(scene.path);
        }
        return scenes.ToArray();
	}


}