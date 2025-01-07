using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ToggleConvexWithChildren : MonoBehaviour
{
    private MeshCollider meshCollider;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        // Referenzen holen
        meshCollider = GetComponent<MeshCollider>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (meshCollider == null)
        {
            Debug.LogError("Kein MeshCollider auf dem Hauptobjekt gefunden!");
            return;
        }

        if (grabInteractable == null)
        {
            Debug.LogError("Kein XRGrabInteractable auf dem Hauptobjekt gefunden!");
            return;
        }

        // Event-Listener hinzufügen
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log("Objekt wird gegriffen: Collider ändern");
        ChangeConvexState(false);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        Debug.Log("Objekt losgelassen: Collider zurücksetzen");
        ChangeConvexState(true);
    }

    private void ChangeConvexState(bool isConvex)
    {
        // Collider am Hauptobjekt ändern
        if (meshCollider != null)
        {
            meshCollider.convex = isConvex;
        }

        // Collider an Child-Objekten ändern
        foreach (Transform child in transform)
        {
            MeshCollider childMeshCollider = child.GetComponent<MeshCollider>();
            if (childMeshCollider != null)
            {
                childMeshCollider.convex = isConvex;
                Debug.Log($"Collider von {child.name} geändert zu convex: {isConvex}");
            }
        }
    }

    void OnDestroy()
    {
        // Event-Listener entfernen
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
            grabInteractable.selectExited.RemoveListener(OnRelease);
        }
    }
}