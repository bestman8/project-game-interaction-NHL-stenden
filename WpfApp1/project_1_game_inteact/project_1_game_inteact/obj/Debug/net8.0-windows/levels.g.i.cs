﻿#pragma checksum "..\..\..\levels.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EE41E86B008AE004F516632ECCBB2E41BF0C49D8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using UItest;


namespace UItest {
    
    
    /// <summary>
    /// levels
    /// </summary>
    public partial class levels : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\levels.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image bck_main;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\levels.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button home;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\levels.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Upgrades;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\levels.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Level1;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\levels.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Level2;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\levels.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Level3;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\levels.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label llevels;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/project_1_game_inteact;component/levels.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\levels.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.bck_main = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.home = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\levels.xaml"
            this.home.Click += new System.Windows.RoutedEventHandler(this.home_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Upgrades = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\levels.xaml"
            this.Upgrades.Click += new System.Windows.RoutedEventHandler(this.upgrades_click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Level1 = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\levels.xaml"
            this.Level1.Click += new System.Windows.RoutedEventHandler(this.level1_click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Level2 = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\levels.xaml"
            this.Level2.Click += new System.Windows.RoutedEventHandler(this.level2_click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Level3 = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\levels.xaml"
            this.Level3.Click += new System.Windows.RoutedEventHandler(this.level3_click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.llevels = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

