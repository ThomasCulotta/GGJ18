using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 20f;
    
	void Update ()
    {
        transform.Rotate(0f, _rotationSpeed * Time.deltaTime, 0f);
	}
}
