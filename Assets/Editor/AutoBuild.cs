using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class AutoBuild
{
	public static void BuildAPK()
	{
		PlayerSettings.bundleIdentifier = "com.xclouder.demo";
        PlayerSettings.productName = "pipelinedemo";

        var outPath = GetOutPath();
        Debug.Log("outPath:" + outPath);
        BuildPipeline.BuildPlayer(GetScenes(), outPath, BuildTarget.Android, BuildOptions.None);
	}

	static string[] GetScenes()
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

	static string GetOutPath()
	{

		string[] args = System.Environment.GetCommandLineArgs();

        for (int i = 0; i < args.Length; ++i)
        {
            if (args[i].Equals("-outPath"))
            {
                if (i + 1 < args.Length)
                {
                    var outPath = args[i + 1];
                    Debug.Log("outPath:" + outPath);

                    return outPath;
                }
            }
        }

        return null;

	}


}