using UnityEngine;

public class IceFactory : AbstractFactory
{
    protected override void CreateArcher()
    {
        Debug.Log("CreateFireArcher");
    }

    protected override void CreateWarrior()
    {
        Debug.Log("CreateFireWarrior");
    }
}
