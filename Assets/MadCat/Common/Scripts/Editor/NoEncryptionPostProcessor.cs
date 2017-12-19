using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;
#if UNITY_IOS
using UnityEditor.iOS.Xcode;
#endif

public class NoEncryptionPostProcessor
{
    [PostProcessBuild]
    public static void SetNoEncryption(BuildTarget buildTarget, string pathToBuiltProject)
    {
#if UNITY_IOS
		if (buildTarget == BuildTarget.iOS)
		{
			string plistPath = pathToBuiltProject + "/Info.plist";
			PlistDocument plist = new PlistDocument();
			plist.ReadFromString(File.ReadAllText(plistPath));

			PlistElementDict rootDict = plist.root;

			rootDict.SetBoolean("ITSAppUsesNonExemptEncryption", false);

			File.WriteAllText(plistPath, plist.WriteToString());
		}
#endif
    }
}
