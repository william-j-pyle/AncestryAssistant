﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("AncestryAssistant.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property ANCESTRY() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("ANCESTRY", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property ancestry_dna() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("ancestry_dna", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property ancestry_logo() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("ancestry_logo", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property ancestry_view_fan() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("ancestry_view_fan", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property ancestry_view_pedigree() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("ancestry_view_pedigree", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property ancestry_view_tree() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("ancestry_view_tree", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to if (typeof ancestryAssistant === &apos;undefined&apos;)
        '''	ancestryAssistant = {};
        '''
        '''ancestryAssistant.MessageTypes = {};
        '''ancestryAssistant.MessageTypes.MT_PERSON = &apos;person&apos;;
        '''ancestryAssistant.MessageTypes.MT_ACCOUNT = &apos;account&apos;;
        '''ancestryAssistant.MessageTypes.MT_TREES = &apos;trees&apos;;
        '''ancestryAssistant.MessageTypes.MT_PAGE = &apos;page&apos;;
        '''ancestryAssistant.MessageTypes.MT_TABLEDATA = &apos;tabledata&apos;;
        '''ancestryAssistant.MessageTypes.MT_FINDAGRAVE = &apos;findagrave&apos;;
        '''
        '''ancestryAssistant.postMessage = function (msgType, msgKey, payl [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property AssistantAPI() As String
            Get
                Return ResourceManager.GetString("AssistantAPI", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property clipboard_copy() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("clipboard-copy", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property clipboard_cut() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("clipboard-cut", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property clipboard_paste() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("clipboard-paste", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property col_header_filtered() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("col-header-filtered", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property col_header_sort_asc() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("col-header-sort-asc", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property col_header_sort_desc() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("col-header-sort-desc", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property dropdown() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("dropdown", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property event_birth() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("event_birth", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property event_death() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("event_death", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property event_marriage() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("event_marriage", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property familysearch_logo() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("familysearch_logo", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property filepage_back() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("filepage_back", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property filepage_home() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("filepage_home", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property filepage_new() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("filepage_new", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property filepage_open() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("filepage_open", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property findagrave_logo() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("findagrave_logo", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property fold3_logo() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("fold3_logo", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property font_bold() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("font-bold", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property font_color() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("font-color", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property font_italic() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("font-italic", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property font_size_decrease() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("font-size-decrease", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property font_size_increase() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("font-size-increase", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property font_underline() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("font-underline", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property form_close() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("form-close", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property form_max() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("form-max", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property form_min() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("form-min", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property newspaper_logo() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("newspaper_logo", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property notebook_page_new() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("notebook-page-new", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property panel_header_bgpattern() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("panel-header-bgpattern", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property panel_header_close() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("panel-header-close", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property panel_header_menu() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("panel-header-menu", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property panel_header_pin() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("panel-header-pin", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property panel_header_unpinned() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("panel-header-unpinned", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property panel_search() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("panel-search", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to {
        '''  &quot;bars&quot;: [
        '''    {
        '''      &quot;name&quot;: &quot;File&quot;,
        '''      &quot;id&quot;: 0,
        '''      &quot;visible&quot;: true,
        '''      &quot;enabled&quot;: true,
        '''      &quot;showpage&quot;: true,
        '''      &quot;usesgroups&quot;: []
        '''    },
        '''    {
        '''      &quot;name&quot;: &quot;Notebook&quot;,
        '''      &quot;id&quot;: 100,
        '''      &quot;visible&quot;: true,
        '''      &quot;enabled&quot;: true,
        '''      &quot;showpage&quot;: false,
        '''      &quot;usesgroups&quot;: [
        '''        {
        '''          &quot;id&quot;: 1
        '''        }
        '''      ]
        '''    },
        '''    {
        '''      &quot;name&quot;: &quot;Ancestor&quot;,
        '''      &quot;id&quot;: 200,
        '''      &quot;visible&quot;: true,
        '''      &quot;enabled&quot;: true,
        '''      &quot;showpage&quot;: false,
        '''      &quot;usesg [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property Ribbon() As String
            Get
                Return ResourceManager.GetString("Ribbon", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property ribbon_button_dropdown() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("ribbon-button-dropdown", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
    End Module
End Namespace
