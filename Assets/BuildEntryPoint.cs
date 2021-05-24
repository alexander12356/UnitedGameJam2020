using UnityEditor;
using UnityEditor.Build.Reporting;

class BuildEntryPoint
{
    private const string SCENES_PATH = "Assets/Scenes";

    public static void BuildWindowsVersion()
    {
        var report = BuildPipeline.BuildPlayer(
            GetAllScenes(),
            "Build/Windows",
            BuildTarget.StandaloneWindows,
            BuildOptions.None
        );

        EditorApplication.Exit(GetExitCodeForBuildResult(report));
    }

    private static int GetExitCodeForBuildResult(BuildReport buildReport)
    {
        switch (buildReport.summary.result)
        {
            case BuildResult.Succeeded:
                return 0;

            default:
                return 1;
        }
    }

    private static string[] GetAllScenes()
    {
        return new[] { $"{SCENES_PATH}/Start.unity" };
    }
}
