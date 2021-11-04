using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SyncVar][SerializeField] string displayName = "Missing Name";

    [SyncVar(hook =nameof(HandleDisplayColourUpdater))] [SerializeField] Color displayColor;

    [SyncVar(hook =nameof(HandleDisplayNameUpdater))] [SerializeField] string name;

    [SerializeField] Renderer render;

    [SerializeField] TextMeshProUGUI myText;
    
    

    [Server]
    public void SetDisplayName(string newDisplayName)
    {
        displayName = newDisplayName;
    }

    [Server]
    public void SetColor(Color newColor)
    {
        displayColor = newColor;
        ChangeColor(displayColor);
    }

    [Server]
    void ChangeColor(Color newColor)
    {
        var mesh = GetComponent<MeshRenderer>();
        if(mesh)
        {
            var mat = new Material(mesh.sharedMaterial)
            {
                color = newColor
            };
            mesh.sharedMaterial = mat;
        }
    }

    [ContextMenu("UpdateColor")]
    [Server]
    private void UpdateColor()
    {
        displayColor = Color.black;
    }

    public void UpdateName()
    {
        
    }

    private void HandleDisplayColourUpdater( Color oldColour, Color newColour)
    {
        render.material.SetColor("_Color", newColour);
    }

    private void HandleDisplayNameUpdater(string oldName, string newName)
    {
        newName = name;
        myText.text = newName;
    }
}
