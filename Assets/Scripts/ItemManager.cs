using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Stack<GameObject> itemList = new Stack<GameObject>();
    public GameObject itemToPush;
    public static ItemManager instance;

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

        for (int i = 0; i < 16; i++)
        {
            GameObject temp = Instantiate(itemToPush);
            temp.transform.position = new Vector3(0, -400, 0);
            itemList.Push(temp);
        }
    }

    public Item GetCurrentItem()
    {
        if (itemList.Count!=0)
        {
            if (itemList.Pop().TryGetComponent(out Item currentItem))
            {
                return currentItem;
            }
        }

        return null;
    }
}
