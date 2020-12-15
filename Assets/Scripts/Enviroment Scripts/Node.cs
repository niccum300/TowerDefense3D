using UnityEngine;

public class Node : MonoBehaviour
{
    public Material hoverMaterial;
    public Material hoverMaterialError;
    public Vector3 positionOffset;

    private Renderer rend;
    private Material startMaterial;

    [Header("Optional")]
    public GameObject turret;



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

        if (buildManager.BuildTurretOn(this))
        {
            buildManager.ClearTurretToBuild();
            rend.material = hoverMaterial;
        }
        else
            return;
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
