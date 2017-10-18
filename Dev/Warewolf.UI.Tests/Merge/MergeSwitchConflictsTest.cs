﻿using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warewolf.UI.Tests.Explorer.ExplorerUIMapClasses;
using Warewolf.UI.Tests.Merge.MergeConflictsUIMapClasses;

namespace Warewolf.UI.Tests.Merge
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class MergeSwitchConflictsTest
    {
        public const string MergeSwitch = "MergeSwitch";
        [TestMethod]
        [TestCategory("Merge")]
        public void RightClick_On_MergeSwitch_Has_Merge_Option()
        {
            MergeConflictsUIMap.OpenMerge_For_Workflow(MergeSwitch);
            Assert.IsTrue(UIMap.MainStudioWindow.ExplorerContextMenu.Merge.Exists, "Merge option does not show after Right cliking " + MergeSwitch);
        }

        [TestMethod]
        [TestCategory("Merge")]
        public void Click_On_MergeSwitch_Has_Decision_And_Children()
        {
            MergeConflictsUIMap.OpenMerge_For_Workflow(MergeSwitch);
            Assert.IsTrue(UIMap.MainStudioWindow.ExplorerContextMenu.Merge.Exists, "Merge option does not show after Right cliking " + MergeSwitch);
            ExplorerUIMap.Click_Merge_From_Context_Menu();
            Assert.IsTrue(MergeConflictsUIMap.MergeDialogViewWindow.ServerSource.Exists);
            MergeConflictsUIMap.MergeDialogViewWindow.MergeResourceVersionList.WarewolfStudioViewMoListItem.ItemRadioButton.Selected = true;
            Mouse.Click(MergeConflictsUIMap.MergeDialogViewWindow.MergeButton);
            Assert.IsTrue(MergeConflictsUIMap.MainWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.MergeTab.WorkSurfaceContext.ContentDockManager.MergeWorkflowView.ScrollViewerPane.ConflictsTree.DecisionMergeTreeItem.Exists);
        }

        [TestMethod]
        [TestCategory("Merge")]
        public void Click_On_MergeSwitch__Difference_Decision_Add_Decision_On_Design_Surface()
        {
            MergeConflictsUIMap.OpenMerge_For_Workflow(MergeSwitch);
            ExplorerUIMap.Click_Merge_From_Context_Menu();
            Mouse.Click(MergeConflictsUIMap.MergeDialogViewWindow.MergeButton);
            MergeConflictsUIMap.MainWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.MergeTab.WorkSurfaceContext.ContentDockManager.MergeWorkflowView.ScrollViewerPane.ConflictsTree.DecisionMergeTreeItem.DecisionSubTreeItem.MergeButton.Decision_Diff_RadioButton.Selected = true;
            Assert.IsTrue(MergeConflictsUIMap.MainWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.MergeTab.WorkSurfaceContext.ContentDockManager.MergeWorkflowView.UIUserControl_1Custom.UIScrollViewerPane.UIActivityBuilderCustom.UIWorkflowItemPresenteCustom.UIFlowchartCustom.Difference_Decision.Exists, "Dicision from difference was not added to the design surface After checking Radio Button");
        }

        [TestMethod]
        [TestCategory("Merge")]
        public void Expand_MergeSwitch_Difference_Has_2_Assigns()
        {
            MergeConflictsUIMap.OpenMerge_For_Workflow(MergeSwitch);
            ExplorerUIMap.Click_Merge_From_Context_Menu();
            Mouse.Click(MergeConflictsUIMap.MergeDialogViewWindow.MergeButton);
            Mouse.Click(MergeConflictsUIMap.MainWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.MergeTab.WorkSurfaceContext.ContentDockManager.MergeWorkflowView.ScrollViewerPane.ConflictsTree.MergeTreeItem.MergeItemExpander.MergeButton.UIIfNameIsText);
            Assert.IsTrue(MergeConflictsUIMap.MainWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.MergeTab.WorkSurfaceContext.ContentDockManager.MergeWorkflowView.ScrollViewerPane.ConflictsTree.MergeTreeItem.MergeItemExpander.ChildrenConflictsTree.FisrtAssign.Exists);
        }
        
        #region Additional test attributes

        [TestInitialize]
        public void MyTestInitialize()
        {
            UIMap.SetPlaybackSettings();
            UIMap.AssertStudioIsRunning();
        }
        public MergeConflictsUIMap MergeConflictsUIMap
        {
            get
            {
                if (_MergeConflictsUIMap == null)
                {
                    _MergeConflictsUIMap = new MergeConflictsUIMap();
                }

                return _MergeConflictsUIMap;
            }
        }

        private MergeConflictsUIMap _MergeConflictsUIMap;

        UIMap UIMap
        {
            get
            {
                if (_UIMap == null)
                {
                    _UIMap = new UIMap();
                }

                return _UIMap;
            }
        }

        private UIMap _UIMap;

        public ExplorerUIMap ExplorerUIMap
        {
            get
            {
                if (_ExplorerUIMap == null)
                {
                    _ExplorerUIMap = new ExplorerUIMap();
                }

                return _ExplorerUIMap;
            }
        }

        private ExplorerUIMap _ExplorerUIMap;

        #endregion
    }
}