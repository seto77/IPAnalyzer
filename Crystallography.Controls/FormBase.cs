using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Crystallography.Controls;

[System.ComponentModel.ToolboxItem(false)]
public partial class FormBase : Form
{
    //260529Cl 追加: F1 キーで開くオンラインマニュアルのページパス (例: "5-structure-viewer")。
    //  言語接頭辞 (en/ja) と末尾スラッシュは HelpRequested 側で付与する。
    //  null/空 のときは各言語のマニュアルトップを開く。
    /// <summary>
    /// このフォームに対応するオンラインマニュアルのページパス。例: "5-structure-viewer"。
    /// 言語接頭辞 (en/ja) は不要。null または空文字のときは F1 でマニュアルのトップページを開く。
    /// </summary>
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected string HelpPage { get; set; } = null;

    protected FormBase()
    {
        InitializeComponent();
        HelpRequested += FormBase_HelpRequested; //260529Cl 追加: F1 でオンラインマニュアルを開く
    }

    //260529Cl 追加: F1 (HelpRequested) でオンラインマニュアルの該当ページを既定ブラウザで開く
    private void FormBase_HelpRequested(object sender, HelpEventArgs hlpevent)
    {
        hlpevent.Handled = true;
        var en = Thread.CurrentThread.CurrentUICulture.Name == "en";
        const string root = "https://seto77.github.io/ReciPro/";
        var url = string.IsNullOrEmpty(HelpPage)
            ? (en ? root : root + "ja/")                          // ページ未指定 → 言語別トップ
            : root + (en ? "en/" : "ja/") + HelpPage + "/";       // ページ指定あり
        try { Process.Start(new ProcessStartInfo(url) { UseShellExecute = true }); }
        catch { }
    }
}
