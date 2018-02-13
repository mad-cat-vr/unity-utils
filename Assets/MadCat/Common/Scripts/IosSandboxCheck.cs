#if UNITY_IPHONE && !UNITY_EDITOR
using System.Runtime.InteropServices;

public class IosSandboxCheck
{
    [DllImport("__Internal")]
	private static extern bool IosSandboxCheck_IsSandbox();

	public static bool IsSandbox
	{
		get
		{
			return IosSandboxCheck_IsSandbox();
		}
	}
}
#else
public class IosSandboxCheck
{
	public static bool IsSandbox { get { return true; } }
}
#endif
