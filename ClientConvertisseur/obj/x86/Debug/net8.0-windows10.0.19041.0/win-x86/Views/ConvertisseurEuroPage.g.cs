﻿#pragma checksum "C:\Users\yoann\OneDrive\Bureau\COURS_CPE\5IRC\.NET\ClientConvertisseur\Views\ConvertisseurEuroPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "38768F37ED21A3A87B499873E5B8A61E59A0E124A0FD9EFE4A9611F541DFB805"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientConvertisseur.Views
{
    partial class ConvertisseurEuroPage : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2408")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\ConvertisseurEuroPage.xaml line 13
                {
                    this.txtBlock1 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                }
                break;
            case 3: // Views\ConvertisseurEuroPage.xaml line 14
                {
                    this.txtBox1 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 4: // Views\ConvertisseurEuroPage.xaml line 15
                {
                    this.txtBlock2 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                }
                break;
            case 5: // Views\ConvertisseurEuroPage.xaml line 16
                {
                    this.cbxDevise = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ComboBox>(target);
                }
                break;
            case 6: // Views\ConvertisseurEuroPage.xaml line 17
                {
                    this.btn = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.btn).Click += this.BtnConvertir_Click;
                }
                break;
            case 7: // Views\ConvertisseurEuroPage.xaml line 18
                {
                    this.txtBlock3 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                }
                break;
            case 8: // Views\ConvertisseurEuroPage.xaml line 19
                {
                    this.txtBox2 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }


        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2408")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

