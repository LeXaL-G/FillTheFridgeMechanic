using UnityEngine;
using DG.Tweening;

public class Box : MonoBehaviour
{
    private bool isActive;
    private Vector3 startPos;
    public Vector3 destination;
    private Collider coll;

    void Start()
    {
        startPos = transform.position;
        coll = gameObject.GetComponent<Collider>();
    }

    public void OpenBox()
    {
        transform.DOMove(destination, 1);
        transform.DORotate(new Vector3(-40, 0, 0), 1);
        isActive = true;
        coll.enabled = false;
        
    }

    public void CloseBox()
    {
        transform.DOMove(startPos, 1);
        transform.DORotate(new Vector3(-90, 0, 0), 1);
        isActive = false;
        coll.enabled = true;
    }
}