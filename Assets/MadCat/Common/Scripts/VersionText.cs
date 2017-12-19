using UnityEngine;
using UnityEngine.UI;

public class VersionText : MonoBehaviour
{
	void Awake () 
	{
		var uiText = GetComponent<Text>();
		if (uiText != null)
		{
			uiText.text = "v" + Application.version;
		}
	}
}
