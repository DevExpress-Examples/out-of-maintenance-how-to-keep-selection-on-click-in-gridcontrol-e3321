# How to keep selection on click in GridControl


<p>This example illustrates how to implement the keep selection functionality in a manner similar to the one <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraTreeListTreeListOptionsBehavior_KeepSelectedOnClicktopic"><u>OptionsBehavior.KeepSelectedOnClicktopic</u></a> is implemented in TreeList.</p><p>The main idea is to save selection on the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsBaseBaseView_MouseDowntopic"><u>MouseDown</u></a> event and restore it on the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsBaseColumnView_ShownEditortopic"><u>ShownEditor</u></a> event.<br />
</p>

<br/>


