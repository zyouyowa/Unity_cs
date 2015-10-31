using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Reflection;

//webviewはちょっと色々アレかもしれない
public class TwitterWindow : EditorWindow {
    private const BindingFlags _flags_ = BindingFlags.Public | BindingFlags.Static;

    [MenuItem("Window/Twitter")]
    private static void Open() {
        var type = Types.GetType("UnityEditor.Web.WebViewEditorWindow", "UnityEditor.dll");
        var methodInfo = type.GetMethod("Create", _flags_);
        methodInfo = methodInfo.MakeGenericMethod(typeof(TwitterWindow));
        methodInfo.Invoke(null, new object[]{"Twitter", "https://mobile.twitter.com/", 300, 520, 520, 600});
    }
}
