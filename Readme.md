<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128630150/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3321)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/KeepSelection/Form1.cs) (VB: [Form1.vb](./VB/KeepSelection/Form1.vb))
* [KeepSelectionHelper.cs](./CS/KeepSelection/KeepSelectionHelper.cs) (VB: [KeepSelectionHelper.vb](./VB/KeepSelection/KeepSelectionHelper.vb))
* [Program.cs](./CS/KeepSelection/Program.cs) (VB: [Program.vb](./VB/KeepSelection/Program.vb))
<!-- default file list end -->
# How to keep selection on click in GridControl


<p>This example illustrates how to implement the keep selection functionality in a manner similar to the one <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraTreeListTreeListOptionsBehavior_KeepSelectedOnClicktopic"><u>OptionsBehavior.KeepSelectedOnClicktopic</u></a> is implemented in TreeList.</p><p>The main idea is to save selection on the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsBaseBaseView_MouseDowntopic"><u>MouseDown</u></a> event and restore it on the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsBaseColumnView_ShownEditortopic"><u>ShownEditor</u></a> event.<br />
</p>

<br/>


