using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : AbstractFactory<Tower>
{
    public override Tower Create(Tower prefab)
    {
        return Instantiate(prefab, transform);
    }

}
