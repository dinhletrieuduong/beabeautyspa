﻿#pragma checksum "..\..\..\..\Form\CreateOutlet\FormCreateOutlet.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1D58FB6CA26A8381A15B4158F7B4796F73D792E49C71471B77DCBFFD1DA97428"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using SpaManager.Form.CreateOutlet;
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


namespace SpaManager.Form.CreateOutlet {
    
    
    /// <summary>
    /// FormCreateOutlet
    /// </summary>
    public partial class FormCreateOutlet : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\Form\CreateOutlet\FormCreateOutlet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_outletname;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Form\CreateOutlet\FormCreateOutlet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_outletaddress;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Form\CreateOutlet\FormCreateOutlet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_pathimage;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Form\CreateOutlet\FormCreateOutlet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_path;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Form\CreateOutlet\FormCreateOutlet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_OK;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Form\CreateOutlet\FormCreateOutlet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_cancel;
        
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
            System.Uri resourceLocater = new System.Uri("/SpaManager;component/form/createoutlet/formcreateoutlet.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Form\CreateOutlet\FormCreateOutlet.xaml"
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
            this.txt_outletname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txt_outletaddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txt_pathimage = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btn_path = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\Form\CreateOutlet\FormCreateOutlet.xaml"
            this.btn_path.Click += new System.Windows.RoutedEventHandler(this.btn_path_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_OK = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\Form\CreateOutlet\FormCreateOutlet.xaml"
            this.btn_OK.Click += new System.Windows.RoutedEventHandler(this.btn_OK_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_cancel = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\Form\CreateOutlet\FormCreateOutlet.xaml"
            this.btn_cancel.Click += new System.Windows.RoutedEventHandler(this.btn_cancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

