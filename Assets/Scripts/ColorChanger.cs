using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    // Materials to switch between.
    public Material redMaterial;
    public Material greenMaterial;
    public Material blueMaterial; // The initial material.

    private Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = blueMaterial; // Start with the blue material.
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check the tag of the object we collided with.
        if (collision.gameObject.CompareTag("Red"))
        {
            renderer.material = redMaterial; // Change to the red material.
        }
        else if (collision.gameObject.CompareTag("Green"))
        {
            renderer.material = greenMaterial; // Change to the green material.
        }
        else if (collision.gameObject.CompareTag("Blue"))
        {
            renderer.material = blueMaterial; // Change to the green material.
        }
    }
}
