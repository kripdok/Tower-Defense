using UnityEngine;

public class FireFactory : AbstractFactory
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
