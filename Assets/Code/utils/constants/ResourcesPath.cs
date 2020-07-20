using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class ResourcesPath {
    public const string AIRPLANS = "3D_Models\\airplanes\\";
    public const string ENVIRONMENTS = "Terrains\\";

    public static string AIRPLANES_FILE = Application.streamingAssetsPath + "\\files\\airplanes.json";
    public static string SESSIONS_FILE = Application.streamingAssetsPath + "\\files\\sessions.json";
    public static string ENVIRONMENTS_FILE = Application.streamingAssetsPath + "\\files\\environments.json";

    public const string AIRPLANES_IMAGES = "Images\\airplanes\\";
    public const string ENVIRONMENTS_IMAGES = "Images\\environments\\";
}

