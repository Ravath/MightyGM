﻿#pragma checksum "..\..\..\GUIcore\DataObjectListSelector.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2606DB3B60B6C724445AE4678DF99214"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MightyGM.GUIcore;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Xceed.Wpf.Toolkit.PropertyGrid;


namespace MightyGM.GUIcore {
    
    
    /// <summary>
    /// DataObjectListSelector
    /// </summary>
    public partial class DataObjectListSelector : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\GUIcore\DataObjectListSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView xSelectedList;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\GUIcore\DataObjectListSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView xUnselectedList;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\GUIcore\DataObjectListSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MightyGM.GUIcore.Fiche xFiche;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MightyGM;component/guicore/dataobjectlistselector.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GUIcore\DataObjectListSelector.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.xSelectedList = ((System.Windows.Controls.ListView)(target));
            
            #line 18 "..\..\..\GUIcore\DataObjectListSelector.xaml"
            this.xSelectedList.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SelectedList_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 26 "..\..\..\GUIcore\DataObjectListSelector.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 27 "..\..\..\GUIcore\DataObjectListSelector.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Remove_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.xUnselectedList = ((System.Windows.Controls.ListView)(target));
            
            #line 29 "..\..\..\GUIcore\DataObjectListSelector.xaml"
            this.xUnselectedList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.xUnselectedList_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 29 "..\..\..\GUIcore\DataObjectListSelector.xaml"
            this.xUnselectedList.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.List_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.xFiche = ((MightyGM.GUIcore.Fiche)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

