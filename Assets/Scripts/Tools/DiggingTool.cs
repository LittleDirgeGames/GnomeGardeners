using UnityEngine;

public class DiggingTool : CoreTool, ITool
{
    [SerializeField] protected bool is2D;

    public new void Interact(ITool tool = null)
    {
        // todo: gets equipped
        base.Interact(tool);
    }

    public new void UseTool(Vector3 origin, Vector3 direction, float distance)
    {
        if(is2D)

        {

            GridManager gridManager = FindObjectOfType<GridManager>();

            gridManager.ChangeTile(gridManager.GetClosestGrid(origin + direction), GroundType.Arable);

        }

        else

        {

            base.UseTool(origin, direction, distance);

        }
    }

    public new void DropItem(Vector2 position)
    {
        // todo: drop tool
        base.DropItem(position);
        Debug.Log("Dropped digging tool.");
    }
}
