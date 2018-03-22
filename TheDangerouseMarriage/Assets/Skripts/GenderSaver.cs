using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderSaver{
    private static bool isMale;

    public static bool IsMale
    {
        get
        {
            return isMale;
        }

        set
        {
            isMale = value;
        }
    }
}
