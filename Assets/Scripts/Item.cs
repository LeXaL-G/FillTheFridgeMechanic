using UnityEngine;

public class Item : MonoBehaviour
{
    public bool dubleSize;

    public void PlaceItemToGrid(Transform plackingTransform)
    {
        transform.parent = plackingTransform;
        transform.localPosition = Vector3.zero;
        transform.localRotation=Quaternion.Euler(Vector3.zero);
    }
}
