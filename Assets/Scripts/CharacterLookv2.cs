using UnityEngine;

public class CharacterLookv2 : MonoBehaviour
{
    private Camera _camera;


    private void Start()
    {
        _camera = Camera.main;
    }


    private void Update()
    {
        RotatePlayerToCamera();
    }

    void RotatePlayerToCamera()
    {
        Vector3 cameraDirection = _camera.transform.forward;

        cameraDirection.y = 0f;

        Quaternion newRotation = Quaternion.LookRotation(cameraDirection);

        transform.rotation = newRotation;
    }
}
