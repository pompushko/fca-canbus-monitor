using System.Windows.Forms;

namespace CanBusMonitor.UI.Controls
{
    public class CanMonitorTabControl : TabControl
    {
        public CanMonitorTabControl()
        {            
            this.Controls.Add(new CanMonitorTabPage() { Text = "1" });
            this.Controls.Add(new CanMonitorTabPage() { Text = "2" });
            var tabPage = this.Controls[0] as CanMonitorTabPage;
            tabPage.Controls.Add(new Panel() { BackColor = System.Drawing.Color.Yellow, Dock = DockStyle.Fill });
            var tabPage2 = this.Controls[1] as CanMonitorTabPage;
            tabPage2.Controls.Add(new Panel() { BackColor = System.Drawing.Color.Red, Dock = DockStyle.Fill });
        }
    }
}