using UnityEngine;

public class FireFactory : AbstractFactory
{
    public override void CreateArcher()
    {
        Debug.Log("CreateFireArcher");
    }

    public override void CreateWarrior()
    {
        Debug.Log("CreateFireWarrior");
    }
}
