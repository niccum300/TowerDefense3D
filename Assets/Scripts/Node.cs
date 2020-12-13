using UnityEngine;

public class Node : MonoBehaviour
{
    public Material hoverMaterial;
    public Material hoverMaterialError;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Material startMaterial;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startMaterial = rend.material;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (buildManager.GetTurretToBuild() == null)
            return;

        if (turret != null)
        {
            rend.material = hoverMaterialError;
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
        buildManager.ClearTurretToBuild();
    }

    void OnMouseEnter()
    {
        if (buildManager.GetTurretToBuild() == null)
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
