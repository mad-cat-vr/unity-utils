using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
[RequireComponent(typeof(AspectRatioFitter))]
public class RawImageAspectUpdater : MonoBehaviour
{
    RawImage image;
    AspectRatioFitter aspectRatioFitter;
	
	void Awake() 
    {
	    image = GetComponent<RawImage>();
        aspectRatioFitter = GetComponent<AspectRatioFitter>();
	}

    void LateUpdate()
    {
        Update();
    }
	
	void Update()
    {
        if (aspectRatioFitter == null ||
            image == null ||
            image.texture == null)
        {
            return;
        }
	    aspectRatioFitter.aspectRatio = image.texture.width * image.uvRect.width / (float)image.texture.height / image.uvRect.height;
	}
}
