using System.Collections.Generic;
using UnityEditor.AddressableAssets.Build;
using UnityEditor.AddressableAssets.Build.DataBuilders;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

[CreateAssetMenu(fileName = "AddOrRemoveLabelsBuildScript.asset", menuName = "Addressables/Content Builders/Add Or Remove Labels Build Script")]
public class AddOrRemoveLabelsBuildScript : BuildScriptPackedMode
{
    [Header("Add or Remove Labels")]
    [Tooltip("If set to true, labels will be added, otherwise labels will be removed")]
    [SerializeField] private bool m_shouldAddLabels = true;

    [Tooltip("Addressable group names in your Addressables Groups window")]
    [SerializeField] private string[] m_groupNames;

    [Tooltip("Custom labels you want to add or remove")]
    [SerializeField] private string[] m_customLabels;

    public override string Name => "Add Or Remove Labels Build Script";

    protected override TResult BuildDataImplementation<TResult>(AddressablesDataBuilderInput builderInput)
    {
        AddressableAssetSettings addressableSettings = builderInput.AddressableSettings;
        List<string> labels = addressableSettings.GetLabels();

        foreach (string label in m_customLabels)
        {
            if (labels.Contains(label))
                continue;

            if (m_shouldAddLabels)
            {
                addressableSettings.AddLabel(label);
            }
            else
            {
                addressableSettings.RemoveLabel(label);
            }
        }

        return base.BuildDataImplementation<TResult>(builderInput);
    }

    protected override string ProcessGroup(AddressableAssetGroup assetGroup, AddressableAssetsBuildContext aaContext)
    {
        if (!ContainsGroupName(assetGroup.name) || (m_customLabels.Length == 0))
            return base.ProcessGroup(assetGroup, aaContext);

        foreach (AddressableAssetEntry entry in assetGroup.entries)
        {
            foreach (string label in m_customLabels)
            {
                bool doesHaveLabel = entry.labels.Contains(label);
                if (!doesHaveLabel && m_shouldAddLabels)
                {
                    entry.SetLabel(label, true);
                }
                else if(doesHaveLabel && !m_shouldAddLabels)
                {
                    entry.SetLabel(label, false);
                }
            }
        }

        return base.ProcessGroup(assetGroup, aaContext);
    }

    private bool ContainsGroupName(string name)
    {
        for (int i = 0; i < m_groupNames.Length; i++)
        {
            if (m_groupNames[i].Equals(name))
                return true;
        }

        return false;
    }

    public override bool CanBuildData<T>()
    {
        return typeof(T).IsAssignableFrom(typeof(AddressablesPlayerBuildResult));
    }
}