using System;
using UnityEditor.ShortcutManagement;
using UnityEngine;

// ReSharper disable RedundantArgumentDefaultValue

namespace Unity.GraphToolkit.Editor
{
    /// <summary>
    /// An event sent by the Frame All shortcut.
    /// </summary>
    [ToolShortcutEvent(null, id, k_KeyCode, k_Modifiers)]
    [UnityRestricted]
    public class ShortcutFrameAllEvent : ShortcutEventBase<ShortcutFrameAllEvent>
    {
        public const string id = "Frame All";
        const KeyCode k_KeyCode = KeyCode.A;
        const ShortcutModifiers k_Modifiers = ShortcutModifiers.None;
    }

    /// <summary>
    /// An event sent by the Frame Origin shortcut.
    /// </summary>
    [ToolShortcutEvent(null, id, k_KeyCode, k_Modifiers)]
    [UnityRestricted]
    public class ShortcutFrameOriginEvent : ShortcutEventBase<ShortcutFrameOriginEvent>
    {
        public const string id = "Frame Origin";
        const KeyCode k_KeyCode = KeyCode.O;
        const ShortcutModifiers k_Modifiers = ShortcutModifiers.None;
    }

    /// <summary>
    /// An event sent by the Show Item Library shortcut.
    /// </summary>
    [ToolShortcutEvent(null, id, k_KeyCode, k_Modifiers)]
    [UnityRestricted]
    public class ShortcutShowItemLibraryEvent : ShortcutEventBase<ShortcutShowItemLibraryEvent>
    {
        public const string id = "Show Item Library";
        const KeyCode k_KeyCode = KeyCode.Space;
        const ShortcutModifiers k_Modifiers = ShortcutModifiers.None;
    }

    /// <summary>
    /// An event sent by the Convert Variable And Constant shortcut.
    /// </summary>
    [ToolShortcutEvent(null, id, k_KeyCode, k_Modifiers)]
    [UnityRestricted]
    public class ShortcutConvertConstantAndVariableEvent : ShortcutEventBase<ShortcutConvertConstantAndVariableEvent>
    {
        public const string id = "Convert Variable And Constant";
        const KeyCode k_KeyCode = KeyCode.T;
        const ShortcutModifiers k_Modifiers = ShortcutModifiers.Control | ShortcutModifiers.Shift;
    }

    /* TODO OYT (GTF-804): For V1, access to the Align Items and Align Hierarchy features was removed as they are confusing to users. To be improved before making them accessible again.
    /// <summary>
    /// An event sent by the Align Nodes shortcut.
    /// </summary>
    [ToolShortcutEvent(null, id, k_KeyCode, k_Modifiers)]
    public class ShortcutAlignNodesEvent : ShortcutEventBase<ShortcutAlignNodesEvent>
    {
        public const string id = "Align Nodes";
        const KeyCode k_KeyCode = KeyCode.I;
        const ShortcutModifiers k_Modifiers = ShortcutModifiers.None;
    }

    /// <summary>
    /// An event sent by the Align Hierarchies shortcut.
    /// </summary>
    [ToolShortcutEvent(null, id, k_KeyCode, k_Modifiers)]
    public class ShortcutAlignNodeHierarchiesEvent : ShortcutEventBase<ShortcutAlignNodeHierarchiesEvent>
    {
        public const string id = "Align Hierarchies";
        const KeyCode k_KeyCode = KeyCode.I;
        const ShortcutModifiers k_Modifiers = ShortcutModifiers.Shift;
    }
    */

    /// <summary>
    /// An event sent by the Create Sticky Note.
    /// </summary>
    [ToolShortcutEvent(null, id, k_KeyCode, k_Modifiers)]
    [UnityRestricted]
    public class ShortcutCreateStickyNoteEvent : ShortcutEventBase<ShortcutCreateStickyNoteEvent>
    {
        public const string id = "Create Sticky Note";
        const KeyCode k_KeyCode = KeyCode.BackQuote;
        const ShortcutModifiers k_Modifiers = ShortcutModifiers.Alt;
    }

    /// <summary>
    /// An event sent by the Create Sticky Note.
    /// </summary>
    [ToolShortcutEvent(null, id)]
    [UnityRestricted]
    public class ShortcutCreatePlacematEvent : ShortcutEventBase<ShortcutCreatePlacematEvent>
    {
        public const string id = "Create Placemat";
    }

    /// <summary>
    /// An event sent by the Paste Without Wires shortcut.
    /// </summary>
    /// <remarks>The same shortcut is used for "Paste Transitions as New"</remarks>
    [ToolShortcutEvent(null, id, keyCode, modifiers)]
    [UnityRestricted]
    public class ShortCutPasteWithoutWires : ShortcutEventBase<ShortCutPasteWithoutWires>
    {
        public const string id = "Paste Without Wires";
        const KeyCode keyCode = KeyCode.V;
        const ShortcutModifiers modifiers = ShortcutModifiers.Shift | ShortcutModifiers.Action;
    }

    /// <summary>
    /// An event sent by the Duplicate Without Wires shortcut.
    /// </summary>
    [ToolShortcutEvent(null, id, k_KeyCode, k_Modifiers)]
    [UnityRestricted]
    public class ShortCutDuplicateWithoutWires : ShortcutEventBase<ShortCutDuplicateWithoutWires>
    {
        public const string id = "Duplicate Without Wires";
        const KeyCode k_KeyCode = KeyCode.D;
        const ShortcutModifiers k_Modifiers = ShortcutModifiers.Shift | ShortcutModifiers.Action;
    }
}
