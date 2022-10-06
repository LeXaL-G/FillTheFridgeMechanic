using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public Camera cam;
    private RaycastHit hit;
    private Ray ray;
    public Box ActiveBox;

    public static ClickManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit))
            {
                if (hit.collider.CompareTag("Box"))
                {
                    if (hit.collider.gameObject.TryGetComponent(out Box boxobject))
                    {
                        boxobject.OpenBox();
                        ActiveBox = boxobject;
                    }
                }

                if (hit.collider.CompareTag("Cell"))
                {
                    if (hit.collider.gameObject.TryGetComponent(out Cel cell))
                    {
                        Item currentItem = ItemManager.instance.GetCurrentItem();
                        if (currentItem.dubleSize==false)
                        {
                            if (cell.isUpFull==false)
                            {
                                currentItem.PlaceItemToGrid(cell.upPoint);
                                cell.isUpFull = true;
                            }else if (cell.isDownFull==false)
                            {
                                currentItem.PlaceItemToGrid(cell.downPoint);
                                cell.isDownFull = true;
                            }
                            else
                            {
                                if (cell.isUpFull==false&&cell.isDownFull==false)
                                {
                                    currentItem.PlaceItemToGrid(cell.upPoint);
                                    cell.isDownFull = true;
                                    cell.isUpFull = true;
                                }
                            }
                        }
                    }
                }
            }
        }  
    }
}
