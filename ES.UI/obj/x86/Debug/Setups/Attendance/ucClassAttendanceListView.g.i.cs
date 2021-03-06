﻿#pragma checksum "..\..\..\..\..\Setups\Attendance\ucClassAttendanceListView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "452A327D7435DEF96A236ACE2D89F921"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ES.UI;
using ExtendedGrid.ExtendedColumn;
using ExtendedGrid.ExtendedGridControl;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace ES.UI.Setups {
    
    
    /// <summary>
    /// ucClassAttendanceListView
    /// </summary>
    public partial class ucClassAttendanceListView : ES.UI.BaseUserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\..\Setups\Attendance\ucClassAttendanceListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ES.UI.Setups.ucClassAttendanceListView ClassAttendanceUserControl;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\..\Setups\Attendance\ucClassAttendanceListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ShellHeader;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\..\Setups\Attendance\ucClassAttendanceListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbClassList;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\Setups\Attendance\ucClassAttendanceListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker radDatePicker;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\Setups\Attendance\ucClassAttendanceListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnViewAttendance;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\..\Setups\Attendance\ucClassAttendanceListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMarkAttendance;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\..\Setups\Attendance\ucClassAttendanceListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ExtendedGrid.ExtendedGridControl.ExtendedDataGrid gvClassAttendanceListView;
        
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
            System.Uri resourceLocater = new System.Uri("/ES.UI;component/setups/attendance/ucclassattendancelistview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Setups\Attendance\ucClassAttendanceListView.xaml"
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
            this.ClassAttendanceUserControl = ((ES.UI.Setups.ucClassAttendanceListView)(target));
            return;
            case 2:
            this.ShellHeader = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.cmbClassList = ((System.Windows.Controls.ComboBox)(target));
            
            #line 36 "..\..\..\..\..\Setups\Attendance\ucClassAttendanceListView.xaml"
            this.cmbClassList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbClassList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.radDatePicker = ((System.Windows.Controls.DatePicker)(target));
            
            #line 50 "..\..\..\..\..\Setups\Attendance\ucClassAttendanceListView.xaml"
            this.radDatePicker.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.cmbClassList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnViewAttendance = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\..\..\Setups\Attendance\ucClassAttendanceListView.xaml"
            this.btnViewAttendance.Click += new System.Windows.RoutedEventHandler(this.btnViewAttendance_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnMarkAttendance = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\..\..\Setups\Attendance\ucClassAttendanceListView.xaml"
            this.btnMarkAttendance.Click += new System.Windows.RoutedEventHandler(this.btnMarkAttendance_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.gvClassAttendanceListView = ((ExtendedGrid.ExtendedGridControl.ExtendedDataGrid)(target));
            return;
            case 8:
            
            #line 123 "..\..\..\..\..\Setups\Attendance\ucClassAttendanceListView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btnCMEdit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

