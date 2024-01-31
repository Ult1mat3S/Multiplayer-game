using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutomatic : Gun
{
    public override void Use()
    {
        Debug.Log("using gun " + itemInfo.itemName);
    }
}
