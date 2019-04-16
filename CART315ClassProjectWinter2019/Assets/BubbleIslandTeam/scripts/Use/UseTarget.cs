using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UseTarget : MonoBehaviour
{
    [System.Serializable]
    public class UseEvent : UnityEvent<bool>
    {
    }
    
    public bool shouldBeDestroyedAfterUse = false;
    /**
     * In the Unity editor, set a callback function
     * that will be triggered whenever this
     * use target gets used
     */
    public UseEvent OnItemUsed;

    /**
     * Can be called by another script to perform
     * "use" on this target. This causes the
     * callback to trigger
     */
    public void Use(bool engage = false)
    {
        if (OnItemUsed != null)
        {
            OnItemUsed.Invoke(engage);
            
            if (shouldBeDestroyedAfterUse)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
