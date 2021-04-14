using UnityEngine;

public interface ITool : IInteractable, IHeldItem
{
    ToolType Type { get; }

    void UseTool(Vector3 origin, Vector3 direction, float distance);
}

public enum ToolType
{
    Carrying,
    Digging,
    Watering,
    Harvesting,

    Count
}