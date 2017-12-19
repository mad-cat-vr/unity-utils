using UnityEditor;
using UnityEngine;

public static class ClearPlayerPrefs
{
	[MenuItem("Tools/Clear PlayerPrefs")]
	public static void ClearPlayerPrefsAction()
	{
		PlayerPrefs.DeleteAll();
	}
}
