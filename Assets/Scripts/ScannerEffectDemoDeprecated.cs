using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScannerEffectDemoDeprecated : MonoBehaviour
{
	public Material EffectMaterial;
	public float ScanDistance;
    public float ScanSpeed;

    private Transform GoalOrigin;
	private Camera _camera;
    private float MaxScan;
    private AudioSource pingsound;
    
    private Vector3 ScannerOriginPosition;
    
	bool _scanning;
    bool scandelay;
    float scandelaytime;

    // VR Controller
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

	void Start()
	{
        ScanDistance     = 0;
        ScanSpeed        = 4;
        MaxScan          = -1;
        pingsound        = gameObject.GetComponent<AudioSource>();
        scandelay        = false;
        scandelaytime    = 1f;
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

	void Update()
	{
        device = SteamVR_Controller.Input((int)trackedObject.index);
        if (device.GetPressDown(triggerButton) && !scandelay)
		{
            scandelay = true;
			_scanning = true;
			ScanDistance = 0;
            ScannerOriginPosition = transform.position;
            pingsound.pitch = Random.Range(0.8f, 1.1f);
            pingsound.Play();
		}
	}


    void OnEnable()
	{
        _camera = Camera.main;
        _camera.depthTextureMode = DepthTextureMode.Depth;
	}

	[ImageEffectOpaque]
	void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		EffectMaterial.SetVector("_WorldSpaceScannerPos", ScannerOriginPosition); //////////////////////////////////////
		EffectMaterial.SetFloat("_ScanDistance", ScanDistance);
        EffectMaterial.SetVector("_GoalWorldSpaceScannerPos", GoalOrigin.position);
        RaycastCornerBlit(src, dst, EffectMaterial);
	}

	void RaycastCornerBlit(RenderTexture source, RenderTexture dest, Material mat)
	{
		// Compute Frustum Corners
		float camFar = _camera.farClipPlane;
		float camFov = _camera.fieldOfView;
		float camAspect = _camera.aspect;

		float fovWHalf = camFov * 0.5f;

		Vector3 toRight = _camera.transform.right * Mathf.Tan(fovWHalf * Mathf.Deg2Rad) * camAspect;
		Vector3 toTop = _camera.transform.up * Mathf.Tan(fovWHalf * Mathf.Deg2Rad);

		Vector3 topLeft = (_camera.transform.forward - toRight + toTop);
		float camScale = topLeft.magnitude * camFar;

		topLeft.Normalize();
		topLeft *= camScale;

		Vector3 topRight = (_camera.transform.forward + toRight + toTop);
		topRight.Normalize();
		topRight *= camScale;

		Vector3 bottomRight = (_camera.transform.forward + toRight - toTop);
		bottomRight.Normalize();
		bottomRight *= camScale;

		Vector3 bottomLeft = (_camera.transform.forward - toRight - toTop);
		bottomLeft.Normalize();
		bottomLeft *= camScale;

		// Custom Blit, encoding Frustum Corners as additional Texture Coordinates
		RenderTexture.active = dest;

		mat.SetTexture("_MainTex", source);

		GL.PushMatrix();
		GL.LoadOrtho();

		mat.SetPass(0);

		GL.Begin(GL.QUADS);

		GL.MultiTexCoord2(0, 0.0f, 0.0f);
		GL.MultiTexCoord(1, bottomLeft);
		GL.Vertex3(0.0f, 0.0f, 0.0f);

		GL.MultiTexCoord2(0, 1.0f, 0.0f);
		GL.MultiTexCoord(1, bottomRight);
		GL.Vertex3(1.0f, 0.0f, 0.0f);

		GL.MultiTexCoord2(0, 1.0f, 1.0f);
		GL.MultiTexCoord(1, topRight);
		GL.Vertex3(1.0f, 1.0f, 0.0f);

		GL.MultiTexCoord2(0, 0.0f, 1.0f);
		GL.MultiTexCoord(1, topLeft);
		GL.Vertex3(0.0f, 1.0f, 0.0f);

		GL.End();
		GL.PopMatrix();
	}

    public void OnDestroy()
    {
        GoalOrigin = null;
        ScanDistance = 0;
        ScanSpeed = 4;
        MaxScan = -1;
        scandelay = false;
        scandelaytime = 1f;
    }
}
