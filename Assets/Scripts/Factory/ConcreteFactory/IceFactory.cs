using UnityEngine;

public class IceFactory : AbstractFactory
{
    public override void CreateArcher()
    {
        Debug.Log("CreateIceArcher");
    }

    public override void CreateWarrior()
    {
        Debug.Log("CreateIceWarrior");
    }
}