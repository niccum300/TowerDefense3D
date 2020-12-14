using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        if (PlayerStats.Money < standardTurret.cost)
            return;
        
        buildManager.SelectTurretToBuild(standardTurret);
    }
}
