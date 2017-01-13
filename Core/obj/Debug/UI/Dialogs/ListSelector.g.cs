﻿#pragma checksum "..\..\..\..\UI\Dialogs\ListSelector.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5EBDB343A8405F81A738342C2015227F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Core.Data;
using Core.UI;
using Core.UI.Dialogs;
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


namespace Core.UI.Dialogs {
    
    
    /// <summary>
    /// ListSelector
    /// </summary>
    public partial class ListSelector : Core.UI.Dialogs.AbsListSelector, System.Windows.Markup.IComponentConnector {
        
        
        #line 50 "..\..\..\..\UI\Dialogs\ListSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView xSelectedList;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\UI\Dialogs\ListSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView xUnselectedList;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\UI\Dialogs\ListSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Core.UI.Fiche xFiche;
        
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
            System.Uri resourceLocater = new System.Uri("/Core;component/ui/dialogs/listselector.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Dialogs\ListSelector.xaml"
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
            
            #line 51 "..\..\..\..\UI\Dialogs\ListSelector.xaml"
            this.xSelectedList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.xUnselectedList_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 52 "..\..\..\..\UI\Dialogs\ListSelector.xaml"
            this.xSelectedList.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SelectedList_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 55 "..\..\..\..\UI\Dialogs\ListSelector.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 56 "..\..\..\..\UI\Dialogs\ListSelector.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Remove_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.xUnselectedList = ((System.Windows.Controls.ListView)(target));
            
            #line 59 "..\..\..\..\UI\Dialogs\ListSelector.xaml"
            this.xUnselectedList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.xUnselectedList_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 60 "..\..\..\..\UI\Dialogs\ListSelector.xaml"
            this.xUnselectedList.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.List_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.xFiche = ((Core.UI.Fiche)(target));
            return;
            case 6:
            
            #line 64 "..\..\..\..\UI\Dialogs\ListSelector.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 65 "..\..\..\..\UI\Dialogs\ListSelector.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Done);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 66 "..\..\..\..\UI\Dialogs\ListSelector.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Create);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

