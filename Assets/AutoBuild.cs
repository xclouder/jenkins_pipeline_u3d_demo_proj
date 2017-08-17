using UnityEngine;
using UnityEditor;

public class AutoBuild
{
	public void BuildAPK()
	{
		PlayerSettings.bundleIdentifier = "com.xclouder.demo";
        PlayerSettings.productName = "pipelinedemo";

        BuildPipeline.BuildPlayer(GetScenes(), GetOutPath(), BuildTarget.Android, BuildOptions.None);
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

	string GetOutPath()
	{

		string[] args = System.Environment.GetCommandLineArgs();

        for (int i = 0; i < args.Length; ++i)
        {
            if (args[i].Equals("-outPath"))
            {
                if (i + 1 < args.Length)
                {
                    return args[i + 1];
                    Debug.Log("m_outPath:" + m_outPath);

                    i++;
                    continue;
                }
            }
        }

        return null;

	}


}