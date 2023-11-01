using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Street : MonoBehaviour
{
    [SerializeField] bool debugLines = false;
    [SerializeField] Transform start, end;
    [SerializeField] List<Street> streetList;

    public Vector3 StreetStart { get => start.position; }
    public Vector3 StreetEnd { get=> end.position; }

    void OnDrawGizmosSelected() {
        if(!debugLines)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(StreetStart, StreetEnd);

        Gizmos.color = Color.blue;
        foreach (var s in streetList) {
            Gizmos.DrawLine(StreetEnd, s.StreetStart);
        }
    }

}
