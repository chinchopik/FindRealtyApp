﻿#pragma checksum "..\..\..\Views\HomeWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9E217EDA5294E01607A39305DA604D339DAF23358F48E87C0B7821BFDCEC88DB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FindRealtyApp.ViewModel;
using FindRealtyApp.Views;
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


namespace FindRealtyApp.Views {
    
    
    /// <summary>
    /// HomeWindow
    /// </summary>
    public partial class HomeWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\Views\HomeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RealEstatesPage;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Views\HomeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonClients;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Views\HomeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonDeals;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Views\HomeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonStatistics;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Views\HomeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonLogOut;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Views\HomeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame MainFrame;
        
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
            System.Uri resourceLocater = new System.Uri("/FindRealtyApp;component/views/homewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\HomeWindow.xaml"
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
            this.RealEstatesPage = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Views\HomeWindow.xaml"
            this.RealEstatesPage.Click += new System.Windows.RoutedEventHandler(this.RealEstatesPage_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ButtonClients = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Views\HomeWindow.xaml"
            this.ButtonClients.Click += new System.Windows.RoutedEventHandler(this.ButtonClients_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ButtonDeals = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\Views\HomeWindow.xaml"
            this.ButtonDeals.Click += new System.Windows.RoutedEventHandler(this.ButtonDeals_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonStatistics = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\Views\HomeWindow.xaml"
            this.ButtonStatistics.Click += new System.Windows.RoutedEventHandler(this.ButtonStatistics_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ButtonLogOut = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\Views\HomeWindow.xaml"
            this.ButtonLogOut.Click += new System.Windows.RoutedEventHandler(this.ButtonLogOut_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.MainFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

