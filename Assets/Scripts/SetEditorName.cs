using TMPro;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class SetEditorName : MonoBehaviour
{
    public TextMeshProUGUI editorName;
    
    void Start()
    {
        editorName.text = GlobalVariables.CareerPath switch
        {
            "GDgodot" => "Godot",
            "GDunity" => "Unity",
            "GDue" => "Unreal engine",
            "WDfrontend" => "Webstorm",
            "WDbackend" => "Visual Studio Code",
            "SEpython" => "PyCharm",
            "SEjava" => "IntelliJ IDEA",
            _ => "Editor"
        };
    }
}
