using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SelectLevel
{
    private static string _namelevel;

    public static void setLevel(string name)
    {
        _namelevel = name;
    }

    public static string getLevel()
    {
        return _namelevel;
    }


}
