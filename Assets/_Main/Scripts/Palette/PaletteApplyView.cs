using UnityEngine;

public class PaletteApplyView : MonoBehaviour
{
    private LODGroup _lodGroup;
    private void Awake()
    {
        _lodGroup = GetComponent<LODGroup>();
    }
    
    public void ApplyPalette(Material material)
    {
        foreach (var lod in _lodGroup.GetLODs())
        {
            foreach (var lodRenderer in lod.renderers)
            {
                lodRenderer.material = material;
            }
        }
    }   
}