using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public bool rotateX = false;
    public bool rotateY = false;
    public bool rotateZ = false;

    void Update()
    {
        // Calculate rotation angles based on boolean values
        float rotationX = rotateX ? rotationSpeed * Time.deltaTime : 0f;
        float rotationY = rotateY ? rotationSpeed * Time.deltaTime : 0f;
        float rotationZ = rotateZ ? rotationSpeed * Time.deltaTime : 0f;

        // Apply rotation to the GameObject
        transform.Rotate(new Vector3(rotationX, rotationY, rotationZ));
    }
}