﻿#pragma checksum "..\..\Knjigovodstvo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3F41E1664C60611931E3E41FCE0E151150EE266199858DEF39B7AF2D6B2C0877"
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
using Wpf_Biblioteka_Zavrsni;


namespace Wpf_Biblioteka_Zavrsni {
    
    
    /// <summary>
    /// Knjigovodstvo
    /// </summary>
    public partial class Knjigovodstvo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Knjigovodstvo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridKnjigovodstvo;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Knjigovodstvo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridKnjigovodstvo2;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Knjigovodstvo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonNazad;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Knjigovodstvo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxPretraga;
        
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
            System.Uri resourceLocater = new System.Uri("/Wpf_Biblioteka_Zavrsni;component/knjigovodstvo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Knjigovodstvo.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            
            #line 8 "..\..\Knjigovodstvo.xaml"
            ((Wpf_Biblioteka_Zavrsni.Knjigovodstvo)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DataGridKnjigovodstvo = ((System.Windows.Controls.DataGrid)(target));
            
            #line 10 "..\..\Knjigovodstvo.xaml"
            this.DataGridKnjigovodstvo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGridKnjigovodstvo_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DataGridKnjigovodstvo2 = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.ButtonNazad = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\Knjigovodstvo.xaml"
            this.ButtonNazad.Click += new System.Windows.RoutedEventHandler(this.ButtonNazad_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBoxPretraga = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\Knjigovodstvo.xaml"
            this.TextBoxPretraga.KeyUp += new System.Windows.Input.KeyEventHandler(this.TextBoxPretraga_KeyUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

