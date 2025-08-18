using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using UnityEditor;
using UnityEditor.AddressableAssets;
using Unity.GraphToolkit.Editor;

using UnityEngine;
using UnityEngine.UIElements;

using USP.AddressablesBuildGraph;

namespace USP.AddressablesBuildGraph
{
    /*/
    public class MyGraphView2 : GraphView
    {
        public MyGraphView2(UnityEditor.EditorWindow window) :
            base(window)
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

    public class MyNode2 : Node
    {
        public MyNode2()
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

    public class EditorWindow2 : UnityEditor.EditorWindow
    {
        #region Static Methods
        [MenuItem("Tools/Addressables Build Graph View 2")]
        private static void GetWindow()
        {
            EditorWindow2 window = CreateWindow();
            window.Show();
        }
        public static EditorWindow2 CreateWindow()
        {
            return EditorWindow.CreateWindow<EditorWindow2>();
        }
        #endregion

        #region Static Fields
        private static int graphViewNameCounter = 0;
        #endregion

        #region Fields
        private string graphViewName;

        private MyGraphView2 graphView;
        #endregion

        #region Properties
        private string GraphViewName
        {
            get
            {
                if (string.IsNullOrEmpty(graphViewName))
                {
                    ++graphViewNameCounter;

                    graphViewName = $"{nameof(EditorWindow2)}{nameof(GraphView)}{graphViewNameCounter}";
                }

                return graphViewName;
            }
        }
        #endregion

        #region Methods
        public void CreateGUI()
        {
            var graphView = new MyGraphView2();
            graphView.StretchToParentSize();
            rootVisualElement.Add(graphView);

            // Example: Add a node when the window opens
            var node1 = new MyNode2();
            node1.SetPosition(new Rect(50, 50, 150, 100));
            graphView.AddElement(node1);

            var node2 = new MyNode2();
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

        private void CreateAndSetupGraphView()
        {
            //var viewModel = CreateGraphRootViewModel(GraphViewName);
            //var viewSelection = CreateGraphViewSelection(viewModel);

            m_GraphView = new GraphView { }; //(this, GraphTool, GraphViewName, viewModel, viewSelection);

            //m_GraphView?.Initialize();
        }

        private void OnInspectorUpdate()
        {
            //m_GraphView?.ProcessOnIdleAgent?.Execute();
        }
        #endregion
    }
    //*/
}

