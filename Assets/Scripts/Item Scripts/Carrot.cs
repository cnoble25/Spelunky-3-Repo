using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : item
{

    public override void giveEffect(GameObject gb)
    {

    }

    public override void removeEffect(GameObject gb)
    {

    }

    public override void giveSuperEffect(GameObject gb)
    {
        gb.GetComponent<Movement>().MainCamera.orthographicSize *= 1.5f;

    }

    public override void removeSuperEffect(GameObject gb)
    {
        gb.GetComponent<Movement>().MainCamera.orthographicSize /= 1.5f;
    }

    new void Throw(GameObject gb)
    {
        base.Throw(gb);
        isThrown = true;
        removeEffect(gb);
        StartCoroutine(returnHitbox());
    }


}
