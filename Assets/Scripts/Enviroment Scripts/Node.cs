using UnityEngine;

public class Node : MonoBehaviour
{
    public Material hoverMaterial;
    public Material hoverMaterialError;
    public Vector3 positionOffset;

    private Renderer rend;
    private Material startMaterial;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;



    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startMaterial = rend.material;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;
        
        buildManager.ClearTurretToBuild();
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
            return;

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        isUpgraded = true;
    }

    void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
            return;

        if (turret != null)
        {
            rend.material = hoverMaterialError;
            return;
        }

        rend.material = hoverMaterial;
    }

    void OnMouseExit()
    {
        rend.material = startMaterial;
    }
}
