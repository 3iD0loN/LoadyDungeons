using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.Experimental.GraphView;

using UnityEngine;
using UnityEngine.UIElements;

using USP.AddressablesBuildGraph;

namespace USP.AddressablesBuildGraph
{
    /*/
    public class MyGraphView : GraphView
    {
        public MyGraphView()
        {
            // Add manipulators for zoom, pan, selection, etc.
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
            //this.AddManipulator(new ContentDragger());
            //this.AddManipulator(new SelectionDragger());
            //this.AddManipulator(new RectangleSelector());
            //this.AddManipulator(new ClickSelector());

            // Add a grid background for visual reference
            GridBackground grid = new GridBackground();
            Insert(0, grid);
        }
    }

    public class MyNode : Node
    {
        public MyNode()
        {
            title = "My Node"; // Set the node title

            // Create input port
            Port inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(float));
            inputPort.portName = "Input";
            inputContainer.Add(inputPort);

            // Create output port
            Port outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(float));
            outputPort.portName = "Output";
            outputContainer.Add(outputPort);

            RefreshExpandedState();
            RefreshPorts();
        }
    }

    public class EditorWindow : UnityEditor.EditorWindow
    {
        #region Static Methods
        [MenuItem("Tools/Run Addressables Build Graph")]
        public static void Y()
        {
            var settings = AddressableAssetSettingsDefaultObject.Settings;

            /// Generate the graph structure (is a blocking call, will take a few seconds, but not as long as a real Addressables build.)
            var buildInfo = AddressablesBuildInfo.Create(settings);

            if (buildInfo == null)
            {
                return;
            }

            const string filePath = "C:\\Users\\joelbarba\\git\\LoadyDungeons\\AddressablesBuildInfo.json";

            // Ensure that the directories in the file path exist.
            EnsureDirectoryExist(filePath);

            // Open a file stream at the file path for writing to the file.
            // It will create a new file or overwrite a previously created file.
            // Will block any concurrent access to the same file.
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamWriter sw = new StreamWriter(bs, Encoding.UTF8))
            {
                // Write all of the byte array representation of the data to the stream.
                sw.Write(buildInfo.ToString());
            }
        }

        public static void EnsureDirectoryExist(string filePath)
        {
            // Extract the directory path for the file.
            // If the file path is a directory it is the same, if the file path points at a file, it attempts to get the parent directory.
            string directoryPath = Path.GetDirectoryName(filePath);

            // If the name of the directory is valid and the directory does not already exist, then:;
            if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
            {
                // Attempt to create the directory.
                Directory.CreateDirectory(directoryPath);
            }
        }

        [MenuItem("Tools/Addressables Build Graph View")]
        private static void GetWindow()
        {
            EditorWindow window = CreateWindow();
            window.Show();
        }
        public static EditorWindow CreateWindow()
        {
            return EditorWindow.CreateWindow<EditorWindow>();
        }
        #endregion

        #region Fields
        private MyGraphView graphView;
        #endregion

        #region Methods
        public void CreateGUI()
        {
            MyGraphView graphView = new MyGraphView();
            graphView.StretchToParentSize();
            rootVisualElement.Add(graphView);

            // Example: Add a node when the window opens
            MyNode node1 = new MyNode();
            node1.SetPosition(new Rect(50, 50, 150, 100));
            graphView.AddElement(node1);

            MyNode node2 = new MyNode();
            node2.SetPosition(new Rect(300, 150, 150, 100));
            graphView.AddElement(node2);

            // Example: Connect the nodes
            Port outputPort1 = node1.outputContainer.Children().OfType<Port>().First();
            Port inputPort2 = node2.inputContainer.Children().OfType<Port>().First();

            Edge edge = new Edge
            {
                output = outputPort1,
                input = inputPort2
            };
            edge.output.Connect(edge);
            edge.input.Connect(edge);
            graphView.AddElement(edge);
        }
        #endregion
    }
    //*/
}

