public class TowerVaultFactory : AbstractFactory<TowerVault>
{
    public override TowerVault Create(TowerVault prefab)
    {
        return Instantiate(prefab, transform);
    }
}