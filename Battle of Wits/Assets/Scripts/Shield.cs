
using UnityEngine;

public class Shield : MonoBehaviour
{
    public bool angleShift = false;

    public bool isAngleShift()
    {
        return angleShift;
    }
    public void setAngleShift()
    {
        angleShift = !angleShift;
    }

}
