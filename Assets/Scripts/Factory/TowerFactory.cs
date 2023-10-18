public class TowerFactory : AbstractFactory<AbstractTower>
{
    public override AbstractTower Create(AbstractTower prefab)
    {
        return Instantiate(prefab, transform);
    }

}
