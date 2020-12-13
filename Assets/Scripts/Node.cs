using UnityEngine;

public class Node : MonoBehaviour
{
    public Material hoverMaterial;
    public Material hoverMaterialError;

    private GameObject turret;

    private Renderer rend;
    private Material startMaterial;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startMaterial = rend.material;
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            rend.material = hoverMaterialError;
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
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
