﻿#pragma checksum "..\..\..\écrans\EcranCreationCompte.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BDD6D7E03329BE6410C0646C1D507886"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18444
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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


namespace Combaxe___New {
    
    
    /// <summary>
    /// EcranCreationCompte
    /// </summary>
    public partial class EcranCreationCompte : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\écrans\EcranCreationCompte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRetour;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\écrans\EcranCreationCompte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbNomUsager;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\écrans\EcranCreationCompte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pwdboxMdp;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\écrans\EcranCreationCompte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pwdbConfirmMdp;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\écrans\EcranCreationCompte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreerCompte;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\écrans\EcranCreationCompte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblUsager;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\écrans\EcranCreationCompte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMDP;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\écrans\EcranCreationCompte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblConfirmationMDP;
        
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
            System.Uri resourceLocater = new System.Uri("/Combaxe - New;component/%c3%a9crans/ecrancreationcompte.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\écrans\EcranCreationCompte.xaml"
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
            this.btnRetour = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\écrans\EcranCreationCompte.xaml"
            this.btnRetour.Click += new System.Windows.RoutedEventHandler(this.btnRetour_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtbNomUsager = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.pwdboxMdp = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.pwdbConfirmMdp = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            this.btnCreerCompte = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\écrans\EcranCreationCompte.xaml"
            this.btnCreerCompte.Click += new System.Windows.RoutedEventHandler(this.btnCreerCompte_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lblUsager = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblMDP = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblConfirmationMDP = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

