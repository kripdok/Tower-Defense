
public class UnitFactory : AbstractFactory<Unit>
{
    public override Unit Create(Unit prefab)
    {
        return Instantiate(prefab, transform);
    }
}